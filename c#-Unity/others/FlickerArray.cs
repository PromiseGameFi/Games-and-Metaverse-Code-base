using UnityEngine;

public class FlickerArray : MonoBehaviour
{
    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;
    public float flickerSpeed = 0.05f;

    public List<Light> lights;

    void Start()
    {
        // Assign the lights list in the inspector
    }

    void Update()
    {
        foreach(Light light in lights)
        {
            float randomValue = Random.Range(minIntensity, maxIntensity);
            light.intensity = Mathf.Lerp(light.intensity, randomValue, flickerSpeed * Time.deltaTime);
        }
    }
}
