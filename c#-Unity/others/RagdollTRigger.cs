using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTRigger : MonoBehaviour
{
    // A list of the body parts that should be affected by the ragdoll effect
    public List<Rigidbody> bodyParts;
    // The force that will be applied to the body parts when the object is hit
    public float force = 10f;

    private void Start()
    {
        foreach (Rigidbody bodyPart in bodyParts)
        {
            bodyPart.isKinematic = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // If the object is hit by something, trigger the ragdoll effect
        TriggerRagdoll();
    }

    private void TriggerRagdoll()
    {
        // Enable physics on all body parts
        foreach (Rigidbody bodyPart in bodyParts)
        {
            bodyPart.isKinematic = false;
        }
        // Apply a force to all body parts
        foreach (Rigidbody bodyPart in bodyParts)
        {
            bodyPart.AddForce(force * transform.up, ForceMode.Impulse);
        }
    }
}

