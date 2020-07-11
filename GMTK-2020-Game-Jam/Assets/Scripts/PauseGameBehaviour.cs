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

    private void Awake()
    {
        Time.timeScale = 0;
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
        Time.timeScale = 1;
    }


}
