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
    [SerializeField]
    private Color DamageColor;
    private bool isDamaged = false;

    private SpriteRenderer sprite;

    [SerializeField] private int Health = 1;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(AffectedTag) || collision.gameObject.CompareTag("PlayerProjectileUniversal"))
        {
            Health--;
            if (!isDamaged)
            {
                StartCoroutine(IndicateDamage(.5f));
            }
            if(DamageParticle != null && DamagedSprite != null)
            {
                DamageParticle.Play();
                sprite.sprite = DamagedSprite;
            }
            if (Health <= 0)
            {
                Death();
                Destroy(gameObject);
            }
        }
    }

    IEnumerator IndicateDamage(float duration)
    {
        isDamaged = true;
        Color initialColor = sprite.color;
        sprite.color = DamageColor;

        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            sprite.color = Color.Lerp(DamageColor, initialColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDamaged = false;

    }

    private void Death()
    {
        if(Camera.main != null && OptionsContainer.DoScreenShake)
        {
            Camera.main.GetComponent<CameraShake>().Shake(.25f, .02f);
        }
        AudioSource.PlayClipAtPoint(DeathSound, transform.position, OptionsContainer.Volume);
        Instantiate(DeathParticle, transform.position, transform.rotation);
        PlayerBehaviour.Score += ScoreValue;
    }
}
