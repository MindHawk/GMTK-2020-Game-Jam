﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourComponent : MonoBehaviour
{
    [SerializeField]
    private string AffectedTag;
    [SerializeField]
    private ParticleSystem DeathParticle;
    [SerializeField]
    private AudioClip DeathSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(AffectedTag))
        {
            Death();
            Destroy(this.gameObject);
        }
    }

    private void Death()
    {
        if(Camera.main != null)
        {
            Camera.main.GetComponent<CameraShake>().Shake(.25f, .02f);
        }
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
    }
}
