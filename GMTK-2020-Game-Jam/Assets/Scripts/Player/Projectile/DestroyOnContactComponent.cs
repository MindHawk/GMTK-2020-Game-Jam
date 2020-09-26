using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContactComponent : MonoBehaviour
{
    [SerializeField]
    private List<string> targetTags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetTags.Contains(collision.gameObject.tag))
        {
            Destroy(this.gameObject);
        }
    }
}
