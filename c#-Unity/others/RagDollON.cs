using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Change the player tag to vehicle
public class RagDollON : MonoBehaviour
{
    public BoxCollider mainCollider;
    public GameObject ThePlayerq;
    public Animator TheseGuys;
    // Start is called before the first frame update
    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vehicle")
        {
            RagdollModeOn();
        }
    }
    Collider[] ragdolColliders;
    Rigidbody[] limbsRigidbodies; 
    void GetRagdollBits()
    {
        ragdolColliders = ThePlayerq.GetComponentsInChildren<Collider>();
        limbsRigidbodies = ThePlayerq.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {
        TheseGuys.enabled = false;
        foreach (Collider col in ragdolColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }
        
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    void RagdollModeOff()
    {
        foreach (Collider col in ragdolColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }
        TheseGuys.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
