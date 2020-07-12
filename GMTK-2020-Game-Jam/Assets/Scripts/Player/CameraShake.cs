using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool isShaking = false;
    public void Shake(float duration, float magnitude)
    {
        if (!isShaking)
        {
            isShaking = true;
            StartCoroutine(ShakeScreen(duration, magnitude));
        }
    }
    private IEnumerator ShakeScreen(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;

        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
        isShaking = false;
    }
}
