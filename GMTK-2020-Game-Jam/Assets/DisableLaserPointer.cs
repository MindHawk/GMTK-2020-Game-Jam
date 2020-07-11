using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLaserPointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!OptionsContainer.UseLaserPointer)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
