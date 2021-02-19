using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSlashAlpha : MonoBehaviour
{
    public float startSeconds=0.0f;
    public float endSeconds = 5.0f;

    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(FadeTo(startSeconds, endSeconds));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().color.a;
        for (float t = startSeconds; t < endSeconds; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(255, 0, 0, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }

}
