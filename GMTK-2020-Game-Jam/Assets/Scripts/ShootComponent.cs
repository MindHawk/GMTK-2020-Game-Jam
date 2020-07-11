using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    private Rigidbody2D parentRigidBody;
    [Header("Projectile Atributes")]
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float projectileSpeed = 5;
    [SerializeField]
    private float torque = 3;
    [SerializeField]
    private float shotCooldown = 1;
    [SerializeField]
    private List<Transform> ProjectileOrigins;
    [SerializeField]
    private List<ParticleSystem> SmokeParticles;
    private bool canShoot = true;
    private int lastProjectileOrigin = 0;

    private void Awake()
    {
        parentRigidBody = GetComponentInParent<Rigidbody2D>();
    }
    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            parentRigidBody.AddTorque(torque, ForceMode2D.Impulse);
            InstantiateProjectile();
            PlayParticleSystem();
            StartCoroutine(ShotCooldown());
        }
    }

    private IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }

    private void InstantiateProjectile()
    {
        GameObject instantiatedProjectile = Instantiate(projectile, GetNextProjectileOrigin().position, transform.rotation);
        instantiatedProjectile.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * projectileSpeed, ForceMode2D.Impulse);
    }

    private Transform GetNextProjectileOrigin()
    {
        if(ProjectileOrigins.Count == 1)
        {
            lastProjectileOrigin = 0;
            return ProjectileOrigins[0];
        }
        else
        {
            lastProjectileOrigin += 1;
            if(lastProjectileOrigin == ProjectileOrigins.Count)
            {
                lastProjectileOrigin = 0;
            }
        }
        Transform nextOrigin = ProjectileOrigins[lastProjectileOrigin];
        return nextOrigin;
    }

    private void PlayParticleSystem()
    {
        SmokeParticles[lastProjectileOrigin].Play();
    }
}
