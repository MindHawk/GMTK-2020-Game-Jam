using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField]
    private float PostDetonationSpeed = 0;

    public UnityEvent Detonation = new UnityEvent();

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
        Detonation.Invoke();
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        hasDetonated = true;
        DetonationEffect.Play();
        GetComponent<CircleCollider2D>().radius = DetonationRange;
        rigidbody.velocity = rigidbody.velocity.normalized * PostDetonationSpeed;
        Destroy(gameObject, DetonationDuration);
    }
}
