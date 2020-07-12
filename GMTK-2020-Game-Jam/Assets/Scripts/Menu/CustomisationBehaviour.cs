using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomisationBehaviour : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI HighScoreText;
    private void Awake()
    {
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
}
