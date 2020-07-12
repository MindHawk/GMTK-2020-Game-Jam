using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonParentBehaviour : MonoBehaviour
{
    private ShootComponent cannon;
    private void Start()
    {
        cannon = GetComponentInChildren<ShootComponent>();
    }
    public void Shoot()
    {
        cannon.Shoot();
    }
}
