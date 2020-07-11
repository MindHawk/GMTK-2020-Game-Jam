using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourComponent : MonoBehaviour
{
    [SerializeField]
    private string AffectedTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(AffectedTag))
        {
            Destroy(this.gameObject);
        }
    }
}
