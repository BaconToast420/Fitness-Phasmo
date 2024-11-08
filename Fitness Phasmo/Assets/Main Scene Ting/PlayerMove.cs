using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject cam;
    
    Rigidbody rb;
    [SerializeField] float walkSpeed;
    Vector2 moveInput, lookInput;

    [SerializeField] float minViewDistance = 25f;

    public float mouseSensitivity = 100f;
    float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        UpdateLookAround();
    }

    void UpdateLookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, minViewDistance);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Move()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * walkSpeed, rb.linearVelocity.y, moveInput.y * walkSpeed);
        rb.linearVelocity = transform.TransformDirection(playerVelocity);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
}
