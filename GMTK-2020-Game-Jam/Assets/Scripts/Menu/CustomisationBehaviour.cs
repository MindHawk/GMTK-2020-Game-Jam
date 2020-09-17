using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomisationBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI HighScoreText;

    private int _selectedShipButton;
    private int _selectedAirButton;
    private int _selectedAbilityButton;

    [SerializeField] private List<Image> shipButtons;
    
    [SerializeField] private List<Image> airButtons;

    [SerializeField] private List<Image> AbilityButtons;

    [SerializeField] private Sprite selectedSprite;

    private void Awake()
    {
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        _selectedShipButton = PlayerPrefs.GetInt("ShipCannon");
        _selectedAirButton = PlayerPrefs.GetInt("AirCannon");
        _selectedAbilityButton = PlayerPrefs.GetInt("ActiveAbility");

        shipButtons[_selectedShipButton].sprite = selectedSprite;
        airButtons[_selectedAirButton].sprite = selectedSprite;
        AbilityButtons[_selectedAbilityButton].sprite = selectedSprite;

    }

    public void UpdateShipCannonSelection(int value)
    {
        PlayerPrefs.SetInt("ShipCannon", value);
    }

    public void UpdateAirCannonSelection(int value)
    {
        PlayerPrefs.SetInt("AirCannon", value);
    }

    public void UpdateActiveAbilitySelection(int value)
    {
        PlayerPrefs.SetInt("ActiveAbility", value);
    }

    public void JamUnlockAllToggle()
    {
        if(PlayerPrefs.GetInt("UnlockAll") == 0)
        {
            PlayerPrefs.SetInt("UnlockAll", 1);
        }
        else
        {
            PlayerPrefs.SetInt("UnlockAll", 0);
        }
    }
}
