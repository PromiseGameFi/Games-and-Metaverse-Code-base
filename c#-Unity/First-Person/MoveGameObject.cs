using UnityEngine;

public class MoveGameObject : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float MoveSpeedForWASD = 5f;

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontalMovement, 0, verticalMovement) * MoveSpeedForWASD * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * movementSpeed * Time.deltaTime;
        }
    }
}
