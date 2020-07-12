using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootComponent : MonoBehaviour
{
    private Rigidbody2D _parentRigidBody;
    [Header("Projectile Attributes")]
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float projectileSpeed = 5;
    [SerializeField]
    private float torque = 3;
    [SerializeField]
    private float shotCooldown = 1;
    [FormerlySerializedAs("ProjectileOrigins")] [SerializeField]
    private List<Transform> projectileOrigins;
    [FormerlySerializedAs("SmokeParticles")] [SerializeField]
    private List<ParticleSystem> smokeParticles;
    [SerializeField]
    private AudioClip FireSound;
    private bool _canShoot = true;
    private int _lastProjectileOrigin = 0;
    [Header("Multishot")]
    [SerializeField] private bool multiStageShoot = false;
    [SerializeField] private int multiStageShotsAmount = 3;
    [SerializeField] private float multiStageShotsDelay = 0.12f;
    [SerializeField] private int projectilesPerShot = 1; 

    private void Awake()
    {
        _parentRigidBody = GetComponentInParent<Rigidbody2D>();
        _lastProjectileOrigin = (projectileOrigins.Count - 1);
    }
    public void Shoot()
    {
        if (_canShoot)
        {
            _canShoot = false;
            StartCoroutine(ShotCooldown());
            if (multiStageShoot)
            {
                ExecuteShoot();
                for (int i = 1; i < multiStageShotsAmount; i++)
                {
                    StartCoroutine(DelayedShot(i * multiStageShotsDelay));
                }
            }
            else
            {
                ExecuteShoot();
            }
        }
    }

    private void ExecuteShoot()
    {
        for (int i = 0; i < projectilesPerShot; i++)
        {
            _parentRigidBody.AddTorque(torque, ForceMode2D.Impulse);
            InstantiateProjectile();
            PlayParticleSystem();
            PlaySound();
        }
    }
    
    private IEnumerator DelayedShot(float shotDelay)
    {
        yield return new WaitForSeconds(shotDelay);
        ExecuteShoot();
    }

    private IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(shotCooldown);
        _canShoot = true;
    }

    private void InstantiateProjectile()
    {
        Transform nextOrigin = GetNextProjectileOrigin();
        GameObject instantiatedProjectile = Instantiate(projectile, nextOrigin.position, nextOrigin.rotation);
        instantiatedProjectile.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * projectileSpeed, ForceMode2D.Impulse);
    }

    private Transform GetNextProjectileOrigin()
    {
        if(projectileOrigins.Count == 1)
        {
            _lastProjectileOrigin = 0;
            return projectileOrigins[0];
        }
        _lastProjectileOrigin += 1;
        if(_lastProjectileOrigin == projectileOrigins.Count)
        {
            _lastProjectileOrigin = 0;
        }
        Transform nextOrigin = projectileOrigins[_lastProjectileOrigin];
        return nextOrigin;
    }

    private void PlayParticleSystem()
    {
        smokeParticles[_lastProjectileOrigin].Play();
    }

    private void PlaySound()
    {
        AudioSource.PlayClipAtPoint(FireSound, transform.position, OptionsContainer.Volume);
    }
}
