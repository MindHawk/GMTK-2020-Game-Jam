using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public UnityEvent LeftClick = new UnityEvent();
    public UnityEvent RigthClick = new UnityEvent();


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
            RigthClick.Invoke();
        }
    }
}
