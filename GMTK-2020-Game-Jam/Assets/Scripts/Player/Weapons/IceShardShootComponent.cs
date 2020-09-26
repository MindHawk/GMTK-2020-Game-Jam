using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShardShootComponent : ShootComponent
{
    [Header("Frost")]
    [SerializeField]
    private float frostBuildup;
    [SerializeField]
    private float maxFrostBuildup;
    [SerializeField]
    private float frostDecay;
    [SerializeField]
    private float frostDecayDelay;
    private float currentFrostBuildup;
    private float baseDrag;
    [Header("Frost Visuals")]
    [SerializeField]
    private ParticleSystem FrostIndicator;

    private Rigidbody2D parentBody;
    private void Start()
    {
        parentBody = player.GetComponent<Rigidbody2D>();
        baseDrag = parentBody.angularDrag;
        //FrostIndicator.Pause();
    }

    public override void Shoot()
    {
        if(_canShoot && currentFrostBuildup < maxFrostBuildup)
        {
            currentFrostBuildup += frostBuildup;
            StopAllCoroutines();
            StartCoroutine(StartFrostDecay());
        }
        base.Shoot();
    }

    private void FixedUpdate()
    {
        parentBody.angularDrag = baseDrag + currentFrostBuildup;
        if(currentFrostBuildup > maxFrostBuildup)
        {
            currentFrostBuildup = maxFrostBuildup;
        }
        SetFrostIndicator();
    }

    IEnumerator StartFrostDecay()
    {
        yield return new WaitForSeconds(frostDecayDelay);
        while (currentFrostBuildup > 0)
        {
            if (player.GetCurrentHeat() > 0)
            {
                currentFrostBuildup -= player.GetCurrentHeat() * Time.deltaTime;
                player.SetCurrentHeat(0);
            }
            currentFrostBuildup -= frostDecay * Time.deltaTime;
            yield return null;
        }
        currentFrostBuildup = 0;
        yield return null;
    }

    private void SetFrostIndicator()
    {
        float frostFraction = Mathf.Abs(1 - (maxFrostBuildup - currentFrostBuildup) / maxFrostBuildup);
        FrostIndicator.Simulate(frostFraction, false, true);
    }
}
