﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

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
    private float SoundStartTime = 0;
    public bool _canShoot { get; private set; }
    private int _lastProjectileOrigin = 0;
    [Header("Multishot")]
    [SerializeField] private bool multiStageShoot = false;
    [SerializeField] private int multiStageShotsAmount = 3;
    [SerializeField] private float multiStageShotsDelay = 0.12f;
    [SerializeField] private int projectilesPerShot = 1;
    [Header("Heat")]
    [SerializeField]
    private float shotHeatGeneration = 1;
    [Header("Visuals")]
    [SerializeField]
    private bool hasVisualAmmoIndicators = false;
    [SerializeField]
    private List<GameObject> visualAmmoIndicators = new List<GameObject>();
    private int currentProjectileOriginIndex;

    [HideInInspector]
    public PlayerBehaviour player;

    protected UnityEvent Reloaded = new UnityEvent();

    private void Awake()
    {
        _canShoot = true;
        _parentRigidBody = GetComponentInParent<Rigidbody2D>();
        _lastProjectileOrigin = (projectileOrigins.Count - 1);
    }
    public virtual void Shoot()
    {
        if (_canShoot && player.CheckHeat())
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
            player.AddHeat(shotHeatGeneration);
            PlayParticleSystem();
            PlaySound();
            if (hasVisualAmmoIndicators)
            {
                HideAmmoIndicator(currentProjectileOriginIndex);
            }
        }
    }

    private void HideAmmoIndicator(int index)
    {
        visualAmmoIndicators[index].SetActive(false);
        StartCoroutine(ReloadAmmoIndicatorAfterShot(index));
    }

    IEnumerator ReloadAmmoIndicatorAfterShot(int index)
    {
        yield return new WaitForSeconds(shotCooldown);
        visualAmmoIndicators[index].SetActive(true);
    }
    
    private IEnumerator DelayedShot(float shotDelay)
    {
        yield return new WaitForSeconds(shotDelay);
        ExecuteShoot();
    }

    private IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(shotCooldown);
        Reloaded.Invoke();
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
        currentProjectileOriginIndex = _lastProjectileOrigin;
        return nextOrigin;
    }

    private void PlayParticleSystem()
    {
        smokeParticles[_lastProjectileOrigin].Play();
    }

    private void PlaySound()
    {
        if(FireSound != null)
        {
            if(Time.time - SoundStartTime > FireSound.length - .1f || SoundStartTime == 0)
            {
                AudioSource.PlayClipAtPoint(FireSound, transform.position, OptionsContainer.Volume);
                SoundStartTime = Time.time;
            }
        }
    }
}
