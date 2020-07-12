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

    [SerializeField] private Image shipButton1;
    [SerializeField] private Image shipButton2;
    [SerializeField] private Image shipButton3;
    
    [SerializeField] private Image airButton1;
    [SerializeField] private Image airButton2;
    [SerializeField] private Image airButton3;

    [SerializeField] private Sprite selectedSprite;

    private void Awake()
    {
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        _selectedShipButton = PlayerPrefs.GetInt("ShipCannon");
        _selectedAirButton = PlayerPrefs.GetInt("AirCannon");
        switch (_selectedShipButton)
        {
            case 0:
                shipButton1.sprite = selectedSprite;
                break;
            case 1:
                shipButton2.sprite = selectedSprite;
                break;
            case 2:
                shipButton3.sprite = selectedSprite;
                break;
            default:
                break;
        }
        switch (_selectedAirButton)
        {
            case 0:
                airButton1.sprite = selectedSprite;
                break;
            case 1:
                airButton2.sprite = selectedSprite;
                break;
            case 2:
                airButton3.sprite = selectedSprite;
                break;
            default:
                break;
        }
    }

    public void UpdateShipCannonSelection(int value)
    {
        PlayerPrefs.SetInt("ShipCannon", value);
    }

    public void UpdateAirCannonSelection(int value)
    {
        PlayerPrefs.SetInt("AirCannon", value);
    }
}
