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
    [SerializeField]
    private int ScoreValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(AffectedTag))
        {
            Death();
            Destroy(gameObject);
        }
    }

    private void Death()
    {
        if(Camera.main != null && OptionsContainer.DoScreenShake)
        {
            Camera.main.GetComponent<CameraShake>().Shake(.25f, .02f);
        }
        AudioSource.PlayClipAtPoint(DeathSound, transform.position, OptionsContainer.Volume);
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        PlayerBehaviour.Score += ScoreValue;
    }
}
