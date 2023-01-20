using UnityEngine;

public class FlickeringEmission : MonoBehaviour
{
    public Color minEmission = new Color(0.25f, 0.25f, 0.25f);
    public Color maxEmission = new Color(0.5f, 0.5f, 0.5f);
    public float flickerSpeed = 0.05f;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Color randomEmission = Color.Lerp(minEmission, maxEmission, Random.Range(0f,1f));
        renderer.material.SetColor("_EmissionColor", Color.Lerp(renderer.material.GetColor("_EmissionColor"), randomEmission, flickerSpeed * Time.deltaTime));
    }
}
