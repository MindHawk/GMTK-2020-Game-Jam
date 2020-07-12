﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private int lives;
    [SerializeField]
    private List<Image> HealthIcons;
    [SerializeField]
    private GameObject GameOverParent;
    [HideInInspector]
    public static bool isAlive = true;
    [SerializeField]
    private ParticleSystem ExplosionParticle;
    [SerializeField]
    private AudioClip ExplosionSound;
    [HideInInspector]
    public static int Score = 0;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private TextMeshProUGUI HighScoreText;
    [SerializeField]
    private GameObject BrokeRecord;

    private float _immuneTimeRemaining;
    public float ImmuneTime;


    private void FixedUpdate()
    {
        if (ScoreText)
        {
            ScoreText.text = "Score: " + Score;
        }
    }

    private void Awake()
    {
        isAlive = true;
        Score = 0; // Reset score or this carries over between scenes
    }

    private void Update()
    {
        _immuneTimeRemaining -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if (_immuneTimeRemaining >= 0)
            {
                return;
            }
            if(Camera.main != null && OptionsContainer.DoScreenShake)
            {
                Camera.main.GetComponent<CameraShake>().Shake(.5f, .075f);
            }
            AudioSource.PlayClipAtPoint(ExplosionSound, transform.position, OptionsContainer.Volume);
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            if (lives > 1)
            {
                _immuneTimeRemaining = ImmuneTime;
                lives--;
            }
            else
            {
                lives = 0;
                UpdateHealth();
                UpdateHighScore();
                isAlive = false;
                GameOverParent.SetActive(true);
            }
            UpdateHealth();
        }

    }

    private void UpdateHealth()
    {
        foreach (Image image in HealthIcons)
        {
            image.enabled = false;
        }
        for (int i = 0; i < lives; i++)
        {
            HealthIcons[i].enabled = true;
        }
    }

    private void UpdateHighScore()
    {
        int previousRecord = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = "" + previousRecord;
        if(Score > previousRecord)
        {
            BrokeRecord.SetActive(true);
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
