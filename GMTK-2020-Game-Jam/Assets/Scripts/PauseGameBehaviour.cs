using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameBehaviour : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Toggle toggle;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        slider.value = OptionsContainer.Volume;
        toggle.isOn = OptionsContainer.DoScreenShake;
    }
    
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    public void UpdateVolumeValue()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
        OptionsContainer.Volume = slider.value;
    }

    public void UpdateDoScreenShake()
    {
        int screenShakeAsBool = toggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("ScreenShake", screenShakeAsBool);
        OptionsContainer.DoScreenShake = toggle.isOn;
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
    }
}
