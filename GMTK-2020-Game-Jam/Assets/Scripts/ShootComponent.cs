using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    private Rigidbody2D parentRigidBody;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float torque = 3;
    [SerializeField]
    private float shotCooldown = 1;
    private bool canShoot = true;

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
            StartCoroutine(ShotCooldown());
        }
    }

    private IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }
}
