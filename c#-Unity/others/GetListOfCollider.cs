using UnityEngine;
using System.Collections.Generic;

public class Example : MonoBehaviour
{
    void Start()
    {
        // Create a list of colliders from the children of this game object
        List<Collider> colliders = new List<Collider>(GetComponentsInChildren<Collider>());

        // Iterate through the list of colliders and print their names
        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.name);
        }
    }
}
