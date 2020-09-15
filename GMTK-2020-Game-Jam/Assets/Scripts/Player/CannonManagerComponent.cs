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
    private GameObject AbilityParent;
    [SerializeField]
    private List<GameObject> ShipCannons;
    [SerializeField]
    private List<GameObject> AirCannons;
    [SerializeField]
    private List<GameObject> ActiveAbilities;

    private void Awake()
    {
        LoadCannons();
    }

    private void LoadCannons()
    {
        LoadShipCannon();
        LoadAirCannon();
        LoadActiveAbilities();
    }

    private void LoadShipCannon()
    {
        if (ShipCannonParent.transform.childCount > 0)
        {
            for (int i = 0; i < ShipCannonParent.transform.childCount; i++)
            {
                Destroy(ShipCannonParent.transform.GetChild(i).gameObject);
            }
        }
        Instantiate(ShipCannons[PlayerPrefs.GetInt("ShipCannon")], ShipCannonParent.transform);
    }

    private void LoadAirCannon()
    {
        if (AirCannonParent.transform.childCount > 0)
        {
            for (int i = 0; i < AirCannonParent.transform.childCount; i++)
            {
                Destroy(AirCannonParent.transform.GetChild(i).gameObject);
            }
        }
        Instantiate(AirCannons[PlayerPrefs.GetInt("AirCannon")], AirCannonParent.transform);

    }

    private void LoadActiveAbilities()
    {
        if (AbilityParent.transform.childCount > 0)
        {
            for (int i = 0; i < AbilityParent.transform.childCount; i++)
            {
                Destroy(AbilityParent.transform.GetChild(i).gameObject);
            }
        }
        Instantiate(ActiveAbilities[PlayerPrefs.GetInt("ActiveAbility")], AbilityParent.transform);
    }

}
