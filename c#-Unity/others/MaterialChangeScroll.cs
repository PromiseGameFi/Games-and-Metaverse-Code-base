using UnityEngine;


public class MaterialChangeScroll : MonoBehaviour
{
    public Material newMaterial;
    private Material currentMaterial;
    public float offset;
    public float scrollSpeed = 0.1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Get the renderer component of the game object
            Renderer renderer = gameObject.GetComponent<Renderer>();

            // Get the materials array
            Material[] materials = renderer.materials;
            //offset += Time.deltaTime * scrollSpeed;
            newMaterial.SetFloat("_Threshold", offset);
            // Change the material at index 2
            materials[2] = newMaterial;

            // Set the current material
            currentMaterial = materials[2];

            // Set the new materials array
            renderer.materials = materials;
         
            
        }

    

    }
}
