using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContactComponent : MonoBehaviour
{
    [SerializeField]
    private string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Destroy(this.gameObject);
        }
    }
}
