using UnityEngine;
using UnityEngine.Rendering;

public class BloodWithCollider : MonoBehaviour
{
    public bool InfiniteDecal;
    public Light DirLight;
    public GameObject BloodAttach;
    public GameObject[] BloodFX;
    public GameObject spawnPoint;
    public Collider playerCollider;

    Transform GetNearestObject(Transform hit, Vector3 hitPos)
    {
        var closestPos = 100f;
        Transform closestBone = null;
        var childs = hit.GetComponentsInChildren<Transform>();

        foreach (var child in childs)
        {
            var dist = Vector3.Distance(child.position, hitPos);
            if (dist < closestPos)
            {
                closestPos = dist;
                closestBone = child;
            }
        }

        var distRoot = Vector3.Distance(hit.position, hitPos);
        if (distRoot < closestPos)
        {
            closestPos = distRoot;
            closestBone = hit;
        }
        return closestBone;
    }

    public Vector3 direction;
    int effectIdx;
    void Update()
    {
        // Check for a collision with the player's collider
        if (playerCollider.bounds.Intersects(GetComponent<Collider>().bounds))
        {
            // Calculate the angle of the normal of the hit surface
            float angle = Mathf.Atan2(spawnPoint.transform.forward.x, spawnPoint.transform.forward.z) * Mathf.Rad2Deg + 180;

            // Instantiate the blood effect at the hit point
            if (effectIdx == BloodFX.Length) effectIdx = 0;
            var instance = Instantiate(BloodFX[effectIdx], spawnPoint.transform.position, Quaternion.Euler(0, angle + 90, 0));
            effectIdx++;

            // Set the intensity of the blood effect based on the light source
            var settings = instance.GetComponent<BFX_BloodSettings>();
            settings.LightIntensityMultiplier = DirLight.intensity;

            // Set the lifetime of the blood effect based on the InfiniteDecal flag
            if (!InfiniteDecal) Destroy(instance, 20);

            // Get the nearest bone to the hit point and attach the blood attach object to it
            var nearestBone = GetNearestObject(transform.root, spawnPoint.transform.position);
            if (nearestBone != null)
            {
                var attachBloodInstance = Instantiate(BloodAttach);
                var bloodT = attachBloodInstance.transform;
                bloodT.position = spawnPoint.transform.position;
                bloodT.localRotation = Quaternion.identity;
                bloodT.localScale = Vector3.one * Random.Range(0.75f, 1.2f);
                bloodT.LookAt(spawnPoint.transform.position + spawnPoint.transform.forward, direction);
                bloodT.Rotate(90, 0, 0);
                bloodT.transform.parent = nearestBone;
            }
        }
    }
}
