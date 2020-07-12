using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public UnityEvent LeftClick = new UnityEvent();
    public UnityEvent RightClick = new UnityEvent();
    public UnityEvent PauseGame = new UnityEvent();


    private void Update()
    {
        if (PlayerBehaviour.isAlive)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        if (Input.GetAxis("Fire1") != 0)
        {
            LeftClick.Invoke();
        }
        if (Input.GetAxis("Fire2") != 0)
        {
            RightClick.Invoke();
        }
        // DO NOT USE AXIS FOR THIS BUTTON PRESS
        // The axis will not change when timescale = 0
        // Meaning the user repauses every frame they press the resume button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame.Invoke();
        }
    }
}
