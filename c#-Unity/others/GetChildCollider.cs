using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        // Get all of the colliders in the children of this game object
        Collider[] colliders = GetComponentsInChildren<Collider>();

        // Iterate through the array of colliders and print their names
        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.name);
        }
    }
}
