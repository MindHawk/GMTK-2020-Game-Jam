using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameBehaviour : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Toggle toggleScreenShake;
    [SerializeField]
    private Toggle toggleLaserPointer;

    [SerializeField] private GameObject laserPointer;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        slider.value = OptionsContainer.Volume;
        toggleScreenShake.isOn = OptionsContainer.DoScreenShake;
        toggleLaserPointer.isOn = OptionsContainer.UseLaserPointer;
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
        int screenShakeAsInt = toggleScreenShake.isOn ? 1 : 0;
        PlayerPrefs.SetInt("ScreenShake", screenShakeAsInt);
        OptionsContainer.DoScreenShake = toggleScreenShake.isOn;
    }
    
    public void UpdateDoLaserPointer()
    {
        int laserPointerAsInt = toggleLaserPointer.isOn ? 1 : 0;
        PlayerPrefs.SetInt("LaserPointer", laserPointerAsInt);
        bool useLaserPointer = toggleLaserPointer.isOn;
        OptionsContainer.UseLaserPointer = useLaserPointer;
        laserPointer.SetActive(useLaserPointer);
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
    }
}
