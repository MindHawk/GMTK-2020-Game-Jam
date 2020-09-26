using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TutorialScripter : MonoBehaviour
{
    public UnityEvent LeftClick = new UnityEvent();
    public UnityEvent RightClick = new UnityEvent();
    private bool LeftClickAllowed = false;
    private bool RightClickAllowed = false;
    public Rigidbody2D Boat;
    public Rigidbody2D Heli;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;


    private void Start()
    {
        StartCoroutine(Part1());
    }
    
    private IEnumerator Part1()
    {
        yield return new WaitForSeconds(2);
        text1.SetActive(false);
        text2.SetActive(true);
        FreezeBoat();
    }
    
    private IEnumerator Part2()
    {
        yield return new WaitForSeconds(4);
        text3.SetActive(false);
        text4.SetActive(true);
        FreezeHeli();
    }
    
    private IEnumerator Part3()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("PlayScene");
    }

    private void FreezeBoat()
    {
        Boat.simulated = false;
        LeftClickAllowed = true;
    }
    
    private void FreezeHeli()
    {
        Heli.simulated = false;
        Heli.GetComponent<StrafingMoveComponent>().enabled = false;
        RightClickAllowed = true;
    }

    private void Update()
    {
        if (PlayerBehaviour.isAlive)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        if (Input.GetAxis("Fire1") != 0 && LeftClickAllowed)
        {
            LeftClick.Invoke();
            Boat.simulated = true;
            Heli.simulated = true;
            LeftClickAllowed = false;
            text2.SetActive(false);
            text3.SetActive(true);
            StartCoroutine(Part2());
        }
        if (Input.GetAxis("Fire2") != 0 && RightClickAllowed)
        {
            RightClick.Invoke();
            Heli.simulated = true;
            Heli.GetComponent<StrafingMoveComponent>().enabled = true;
            RightClickAllowed = false;
            text4.SetActive(false);
            text5.SetActive(true);
            StartCoroutine(Part3());
        }
    }
}
