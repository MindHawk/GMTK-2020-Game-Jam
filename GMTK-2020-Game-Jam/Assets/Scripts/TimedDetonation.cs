using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDetonation : MonoBehaviour
{
    [SerializeField]
    private float TimeToLive = 10;
    [SerializeField]
    private ParticleSystem DetonationEffect;
    [SerializeField]
    private float DetonationDuration;
    [SerializeField]
    private float DetonationRange;
    private bool hasDetonated = false;

    private float _timeLeft;
    void Start()
    {
        _timeLeft = TimeToLive;
    }

    void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0 && !hasDetonated)
        {
            Detonate();
        }
    }

    private void Detonate()
    {
        hasDetonated = true;
        DetonationEffect.Play();
        GetComponent<CircleCollider2D>().radius = DetonationRange;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Destroy(gameObject, DetonationDuration);
    }
}
