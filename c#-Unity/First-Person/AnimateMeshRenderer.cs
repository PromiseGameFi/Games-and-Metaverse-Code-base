using System.Collections;
using UnityEngine;

public class AnimateMeshRenderer : MonoBehaviour
{
    public float animationDuration = 1f;
    private SkinnedMeshRenderer meshRenderer;
    private Vector3 startScale;

    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        startScale = transform.localScale;
    }

    public void OnEnableThe()
    {
        transform.localScale = new Vector3(startScale.x, 0f, startScale.z);
        meshRenderer.enabled = true;
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float startTime = Time.time;
        while (Time.time < startTime + animationDuration)
        {
            float t = (Time.time - startTime) / animationDuration;
            transform.localScale = new Vector3(startScale.x, Mathf.Lerp(0f, startScale.y, t), startScale.z);
            yield return null;
        }
        transform.localScale = startScale;
    }

    
    
}
