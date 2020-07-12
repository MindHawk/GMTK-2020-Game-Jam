using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManagerComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject ShipCannonParent;
    [SerializeField]
    private GameObject AirCannonParent;
    [SerializeField]
    private List<GameObject> ShipCannons;
    [SerializeField]
    private List<GameObject> AirCannons;

    private void Awake()
    {
        LoadCannons();
    }

    private void LoadCannons()
    {
        LoadShipCannon();
        LoadAirCannon();
    }

    private void LoadShipCannon()
    {
        Instantiate(ShipCannons[PlayerPrefs.GetInt("ShipCannon")], ShipCannonParent.transform);
    }

    private void LoadAirCannon()
    {
        Instantiate(AirCannons[PlayerPrefs.GetInt("AirCannon")], AirCannonParent.transform);

    }

}
