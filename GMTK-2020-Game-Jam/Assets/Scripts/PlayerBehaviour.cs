using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private int lives;
    [SerializeField]
    private GameObject GameOverParent;
    [HideInInspector]
    public static bool isAlive = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            if (lives > 0)
            {
                lives--;
            }
            else
            {
                isAlive = false;
                GameOverParent.SetActive(true);
            }
        }

    }
}
