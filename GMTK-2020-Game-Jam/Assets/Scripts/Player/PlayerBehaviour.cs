using System.Collections;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if(Camera.main != null && OptionsContainer.DoScreenShake)
            {
                Camera.main.GetComponent<CameraShake>().Shake(.5f, .075f);
            }
            AudioSource.PlayClipAtPoint(ExplosionSound, transform.position, OptionsContainer.Volume);
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            if (lives > 1)
            {
                lives--;
            }
            else
            {
                lives = 0;
                UpdateHealth();
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
        if(Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
