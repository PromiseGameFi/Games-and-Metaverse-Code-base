using UnityEditor;
using UnityEngine;

public class GetAllRigid : MonoBehaviour
{
    void Start()
    {
        // Get all of the rigidbodies in the children of this game object
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        // Iterate through the array of rigidbodies and print their names
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }
}
