using UnityEngine;
//Script to add mesh collider to gameObjcets
// Meshcollider can also be changed if the collide you want is different
public class AddCollider : MonoBehaviour
{
    void Start()
    {
        // Get all the child game objects of the parent game object
        GameObject[] children = GetChildGameObjects();

        // Add a mesh collider to each child game object
        foreach (GameObject child in children)
        {
            MeshCollider collider = child.AddComponent<MeshCollider>();
            //collider.convex = true;
        }
    }

    GameObject[] GetChildGameObjects()
    {
        GameObject[] children = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }
        return children;
    }
}
