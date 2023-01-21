using UnityEngine;

public class GetThresholdFromSkinnedMesh : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Material[] materials;
    private float threshold;

    void Start()
    {
        // Get the Skinned Mesh Renderer component
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        // Get the materials array
        materials = skinnedMeshRenderer.materials;

        // Get the threshold value of the material at index 2
        threshold = materials[2].GetFloat("_Threshold");

        // Log the threshold value
        Debug.Log("Threshold: " + threshold);
    }
}
