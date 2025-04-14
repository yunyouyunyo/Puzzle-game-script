using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Transform targetPosition;
    public Image maskImage;
    public float fadeDuration = 10f;
    public float teleportDelay = 10f; // 增加的延遲時間
    private bool lights = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportPlayer(other.transform));
        }
    }

    private IEnumerator TeleportPlayer(Transform playerTransform)
    {
        // Darken the screen
        StartCoroutine(FadeMask(0f, 1f, fadeDuration));

        yield return new WaitForSeconds(teleportDelay); // 增加的延遲時間
 
        // Teleport the player
        playerTransform.position = targetPosition.position;
       
        yield return new WaitForSeconds(teleportDelay); // 增加的延遲時間
            // Lighten the screen
            StartCoroutine(FadeMask(1f, 0f, fadeDuration));
        

    }

    private IEnumerator FadeMask(float startAlpha, float endAlpha, float duration)
    {
        // maskImage.enabled = true;
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
        // maskImage.enabled = false;
    }
}
