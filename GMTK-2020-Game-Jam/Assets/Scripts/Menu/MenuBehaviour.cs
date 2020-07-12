using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public void Awake()
    {
        if (PlayerPrefs.GetFloat("Volume", -1) == -1)
        {
            PlayerPrefs.SetFloat("Volume", 100);
        }
        
        if (PlayerPrefs.GetInt("ScreenShake", -1) == -1)
        {
            PlayerPrefs.SetInt("ScreenShake", 1);
        }
        
        if (PlayerPrefs.GetInt("LaserPointer", -1) == -1)
        {
            PlayerPrefs.SetInt("LaserPointer", 0);
        }
    }
    
    public void SwitchScenes(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
