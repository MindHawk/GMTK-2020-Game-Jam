using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeRingComponent : ShootComponent
{
    [Header("Braking")]
    [SerializeField]
    private float PassiveBrakingForce;
    [SerializeField]
    private float ActiveBrakingForce;
    [SerializeField]
    private float ActiveBrakingTime;
    [Header("Visuals")]
    [SerializeField]
    private List<ParticleSystem> BrakingParticles;

    private Rigidbody2D parentRigidbody;
    private void Start()
    {
        parentRigidbody = player.gameObject.GetComponent<Rigidbody2D>();
        parentRigidbody.angularDrag = PassiveBrakingForce;
    }
    public override void Shoot()
    {
        StartCoroutine(ActiveBrake());
    }

    private IEnumerator ActiveBrake()
    {
        float currentBrakingTime = 0;
        foreach (ParticleSystem particle in BrakingParticles)
        {
            particle.Play();
        }
        while (currentBrakingTime < ActiveBrakingTime)
        {
            parentRigidbody.angularDrag = ActiveBrakingForce;
            currentBrakingTime += Time.deltaTime;
            yield return null;
        }
        parentRigidbody.angularDrag = PassiveBrakingForce;
        foreach (ParticleSystem particle in BrakingParticles)
        {
            particle.Stop();
        }
    }
}
