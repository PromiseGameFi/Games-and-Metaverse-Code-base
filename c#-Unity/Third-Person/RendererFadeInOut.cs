using UnityEngine;

public class RendererFadeInOut : MonoBehaviour
{
    public float fadeTime = 1f; // time for the fade in/out effect
    private Renderer renderer;
    private Color startingColor;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        startingColor = renderer.material.color;
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
            renderer.material.color = Color.Lerp(new Color(startingColor.r, startingColor.g, startingColor.b, 0f), startingColor, t / fadeTime);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float t = fadeTime;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            renderer.material.color = Color.Lerp(startingColor, new Color(startingColor.r, startingColor.g, startingColor.b, 0f), t / fadeTime);
            yield return null;
        }
    }
}
