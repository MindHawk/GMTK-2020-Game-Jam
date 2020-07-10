using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    private Rigidbody2D parentRigidBody;
    public float torque = 3;

    private void Awake()
    {
        parentRigidBody = GetComponentInParent<Rigidbody2D>();
    }
    public void Shoot()
    {
        parentRigidBody.AddTorque(torque, ForceMode2D.Impulse);
    }
}
