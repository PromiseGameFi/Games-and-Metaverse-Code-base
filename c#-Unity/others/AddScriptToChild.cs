using UnityEngine;

public class AddScriptToChild : MonoBehaviour
{
    public MonoBehaviour scriptToAdd;

    void Start()
    {
        // Get all the colliders on the children of this GameObject
        Collider[] colliders = transform.GetComponentsInChildren<Collider>();

        // Iterate through the colliders
        foreach (Collider collider in colliders)
        {
            // Add the script to the GameObject with the collider
            collider.gameObject.AddComponent(scriptToAdd.GetType());
        }
    }
}
