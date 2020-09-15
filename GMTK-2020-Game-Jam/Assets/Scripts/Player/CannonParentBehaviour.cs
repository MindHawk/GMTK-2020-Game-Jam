using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonParentBehaviour : MonoBehaviour
{
    private ShootComponent cannon;
    [SerializeField]
    private PlayerBehaviour player;
    private void Start()
    {
        cannon = GetComponentInChildren<ShootComponent>();
        if(cannon != null)
        {
            cannon.player = player;
        }
    }
    public void Shoot()
    {
        if(cannon != null)
        {
            cannon.Shoot();
        }
    }

    public PlayerBehaviour GetPlayer()
    {
        return player;
    }
}
