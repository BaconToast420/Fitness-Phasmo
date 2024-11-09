using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] float minViewDistance = 25f;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;

    void Update()
    {
        UpdateLookAround();
    }

    void UpdateLookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, minViewDistance);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
