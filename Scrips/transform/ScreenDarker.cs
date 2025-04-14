using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenDarker : MonoBehaviour
{
    public Image maskImage;
    public float fadeDuration = 2f;

    private void Start()
    {
        maskImage.enabled = false;
    }

    public void DarkenScreen()
    {
        Debug.Log("Dark");
        StartCoroutine(FadeMask(0f, 1f, fadeDuration));

    }

    public void LightenScreen()
    {
        StartCoroutine(FadeMask(1f, 0f, fadeDuration));
    }

    private IEnumerator FadeMask(float startAlpha, float endAlpha, float duration)
    {
        maskImage.enabled = true;
        Color startColor = maskImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, endAlpha);
        float elapsedTime = 0f;
       

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            maskImage.color = Color.Lerp(startColor, endColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        maskImage.color = endColor;
        maskImage.enabled = false;
    }
}
