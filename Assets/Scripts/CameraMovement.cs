using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    [SerializeField] private Vector3 movementVector;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        movementVector.x = transform.position.x + Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        movementVector.y = transform.position.y + Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        movementVector.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, movementVector, ref velocity, Time.deltaTime);
    }
}
