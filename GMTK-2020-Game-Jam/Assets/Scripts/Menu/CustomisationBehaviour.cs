using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomisationBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI HighScoreText;
    [SerializeField]
    private TMP_Dropdown ShipDropdown;
    [SerializeField]
    private TMP_Dropdown AirDropdown;

    private void Awake()
    {
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        ShipDropdown.value = PlayerPrefs.GetInt("ShipCannon");
        AirDropdown.value = PlayerPrefs.GetInt("AirCannon");

    }

    public void UpdateShipCannonSelection()
    {
        PlayerPrefs.SetInt("ShipCannon", ShipDropdown.value);
    }

    public void UpdateAirCannonSelection()
    {
        PlayerPrefs.SetInt("AirCannon", AirDropdown.value);
    }
}
