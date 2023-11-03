using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    [SerializeField] private float maxY;
    [SerializeField] private float minY;

    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    [SerializeField] private Vector3 movementVector;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        movementVector.x = Mathf.Clamp(transform.position.x + Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime, minX, maxX);
        movementVector.y = Mathf.Clamp(transform.position.y + Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime, minY, maxY); 
        movementVector.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, movementVector, ref velocity, Time.deltaTime);
    }
}
