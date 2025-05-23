using UnityEngine;
using UnityEngine.UI;

public class FadeFromBlack : MonoBehaviour
{
    public float fadeDuration = 4f;

    private Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        if (fadeImage == null)
        {
            Debug.LogError("FadeFromBlack script must be attached to a UI Image.");
            enabled = false;
            return;
        }

        // Set initial color to fully opaque black
        Color startColor = fadeImage.color;
        startColor.a = 1f;
        fadeImage.color = startColor;

        // Start fade coroutine
        StartCoroutine(FadeOut());
    }

    private System.Collections.IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = fadeImage.color;
        
        yield return new WaitForSeconds(2);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

        // Ensure it's fully transparent and disable the image
        color.a = 0f;
        fadeImage.color = color;
        gameObject.SetActive(false);
    }
}

