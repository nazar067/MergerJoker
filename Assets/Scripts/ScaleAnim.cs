using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnim : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleChange = 0.2f;
    public float duration = 2.0f;

    void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(ScaleAnimationRoutine());
    }

    IEnumerator ScaleAnimationRoutine()
    {
        while (true)
        {
            // Увеличиваем объект
            yield return ScaleOverTime(originalScale, originalScale + new Vector3(scaleChange, scaleChange, scaleChange), duration);

            // Уменьшаем объект
            yield return ScaleOverTime(originalScale + new Vector3(scaleChange, scaleChange, scaleChange), originalScale, duration);
        }
    }

    IEnumerator ScaleOverTime(Vector3 startScale, Vector3 targetScale, float duration)
    {
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
