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
    [SerializeField]
    private ParticleSystem DamageParticle;
    [SerializeField]
    private Sprite DamagedSprite;

    [SerializeField] private int Health = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(AffectedTag))
        {
            Health--;
            if(DamageParticle != null && DamagedSprite != null)
            {
                DamageParticle.Play();
                GetComponentInChildren<SpriteRenderer>().sprite = DamagedSprite;
            }
            if (Health <= 0)
            {
                Death();
                Destroy(gameObject);
            }
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
