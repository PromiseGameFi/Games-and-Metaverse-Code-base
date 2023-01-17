using UnityEngine;

public class FadeInOutArray : MonoBehaviour
{
    public float fadeTime = 1f; // time for the fade in/out effect
    public SkinnedMeshRenderer[] renderers;
    private Color[] startingColors;

    void Start()
    {
        startingColors = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            startingColors[i] = renderers[i].material.color;
        }
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
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = Color.Lerp(new Color(startingColors[i].r, startingColors[i].g, startingColors[i].b, 0f), startingColors[i], t / fadeTime);
            }
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float t = fadeTime;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = Color.Lerp(startingColors[i], new Color(startingColors[i].r, startingColors[i].g, startingColors[i].b, 0f), t / fadeTime);
            }
            yield return null;
        }
    }
}
