using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectCollisionPhysics;

public class CollideDismember : MonoBehaviour
{
    public void Dismember(CollisionData data)
    {
        var joint = data.OtherCollider.GetComponent<JointDismemberPhysics>();
        if (joint)
        {
            joint.BreakJoint();
            data.OtherCollider.GetComponentInParent<CharacterRagdollPhysics>()?.DetachCollider(data.OtherCollider);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Create a CollisionData object and populate it with the necessary information
        CollisionData data = new CollisionData();
        data.OtherCollider = collision.collider;

        // Call the Dismember() function
        Dismember(data);
    }
}
