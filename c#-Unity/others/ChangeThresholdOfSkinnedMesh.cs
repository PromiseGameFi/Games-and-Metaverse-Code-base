using UnityEngine;

public class ChangeThresholdOfSkinnedMesh : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private Material[] materials;
    public float newThreshold = 0.5f;

    void Start()
    {
        // Get the Skinned Mesh Renderer component
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        // Get the materials array
        materials = skinnedMeshRenderer.materials;

        // Change the threshold value of the material at index 2
        materials[2].SetFloat("_Threshold", newThreshold);

        // Log the new threshold value
        Debug.Log("New Threshold: " + materials[2].GetFloat("_Threshold"));
    }
}
