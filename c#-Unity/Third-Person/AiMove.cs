using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject player;
    Rigidbody rigidbody;

    public float movementSpeed = 10;
    public float rotationSpeed = 10;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 aiPosition = transform.position;
        Vector3 moveDirection = Vector3.Normalize(playerPosition - aiPosition);

        rigidbody.MovePosition(transform.position + moveDirection * Time.deltaTime * movementSpeed);

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed));
    }
}
