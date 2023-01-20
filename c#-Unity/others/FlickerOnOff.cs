using UnityEngine;
using System.Collections;

public class FlickerOnOff : MonoBehaviour
{
    public float slowFlickerSpeed = 0.05f;
    public float fastFlickerSpeed = 0.1f;

    public Light[] lights;

    private bool isFastFlickering;
    private float flickerSpeed;

    void Start()
    {
        // Assign the lights array in the inspector
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            flickerSpeed = slowFlickerSpeed;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            isFastFlickering = true;
            flickerSpeed = fastFlickerSpeed;
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            isFastFlickering = false;
        }
    }

    void Update()
    {
        if (isFastFlickering)
        {
            foreach (Light light in lights)
            {
                light.enabled = !light.enabled;
            }
        }
        else
        {
            foreach (Light light in lights)
            {
                light.enabled = !light.enabled;
            }
        }
    }
}
