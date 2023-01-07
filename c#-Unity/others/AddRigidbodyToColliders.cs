using UnityEngine;

public class AddRigidbodyToColliders : MonoBehaviour
{
    void Start()
    {
        // Get all the colliders on the children of this GameObject
        Collider[] colliders = transform.GetComponentsInChildren<Collider>();

        // Iterate through the colliders
        foreach (Collider collider in colliders)
        {
            // Check if the GameObject with the collider doesn't already have a Rigidbody
            if (collider.gameObject.GetComponent<Rigidbody>() == null)
            {
                // Add a Rigidbody to the GameObject with the collider
                collider.gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
