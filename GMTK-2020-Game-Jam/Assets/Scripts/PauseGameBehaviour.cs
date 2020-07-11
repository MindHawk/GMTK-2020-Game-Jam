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
    }
    
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    public void UpdateVolumeValue()
    {
        OptionsContainer.Volume = slider.value;
    }

    public void UpdateDoScreenShake()
    {
        OptionsContainer.DoScreenShake = toggle.isOn;
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
    }
}
