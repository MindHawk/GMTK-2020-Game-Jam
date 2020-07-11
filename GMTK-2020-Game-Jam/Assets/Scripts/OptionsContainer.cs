using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsContainer : MonoBehaviour
{
    public static float Volume = PlayerPrefs.GetFloat("Volume");
    public static bool DoScreenShake = PlayerPrefs.GetInt("ScreenShake") != 0;
}
