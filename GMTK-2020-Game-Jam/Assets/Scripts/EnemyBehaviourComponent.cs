using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourComponent : MonoBehaviour
{
    [SerializeField]
    private string AffectedTag;
    [SerializeField]
    private ParticleSystem DeathParticle;
    [SerializeField]
    private AudioClip DeathSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(AffectedTag))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Camera.main != null)
        {
            Camera.main.GetComponent<CameraShake>().Shake(.5f, .2f);
        }
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
    }
}
