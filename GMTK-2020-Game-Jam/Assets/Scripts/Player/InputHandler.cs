using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public UnityEvent LeftClick = new UnityEvent();
    public UnityEvent RightClick = new UnityEvent();
    public UnityEvent ActiveAbility = new UnityEvent();
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
        if (Input.GetButton("Fire1"))
        {
            LeftClick.Invoke();
        }
        if (Input.GetButton("Fire2"))
        {
            RightClick.Invoke();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            ActiveAbility.Invoke();
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
