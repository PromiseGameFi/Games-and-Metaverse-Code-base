using UnityEngine;
using UnityEngine.UI;

public class ImageFadeInOut : MonoBehaviour
{
    public float fadeTime = 1f; // time for the fade in/out effect
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    void OnDisable()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            image.color = new Color(1f, 1f, 1f, t / fadeTime);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float t = fadeTime;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            image.color = new Color(1f, 1f, 1f, t / fadeTime);
            yield return null;
        }
    }
}
