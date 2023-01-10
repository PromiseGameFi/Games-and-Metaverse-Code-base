using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectCollisionPhysics;

public class ColliderPhysics : ObjectCollisionPhysics
{
    public Collider Sword;
    public Collider Head;
    public GameObject playerHead;
    // Start is called before the first frame update



    // Update is called once per frame
    public void OnCollisionEnter()
    {
        // Check if the colliders intersect
        if (Sword.bounds.Intersects(Head.bounds))
        {
            Debug.Log("Colliders intersect");
            CollisionData data = new CollisionData();
            data.OtherCollider = playerHead.GetComponent<Collider>();
            //data.Point = gameObject.transform.position;
            //playerHead.transform.position = playerBody.transform.position;
            //data.Point = playerHead.transform.position;
            //Vector3 theNewPos = data.Point;
            /**Ray ray = new Ray(Sword.bounds.center, Head.bounds.center - Sword.bounds.center);
            // Set the Point property of the CollisionData object to the point of intersection between the colliders
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                data.Point = hit.point;
                // The colliders intersect, so data.Point has been set to the point of intersection
            }*/



            //playerHead.transform.position = gameObject.transform.position;
            // Call the Dismember() function
            //Dismember(data);
        }
    }
}
