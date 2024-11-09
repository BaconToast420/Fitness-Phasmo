using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public enum ToolType { Flashlight, UVLight}

[System.Serializable]
public class Tool
{
    public string Name;
    public string Beskrivelse;

    public ToolType Type;

    public GameObject GameObject;
}

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject cam;

    Rigidbody rb;
    [SerializeField] float walkSpeed, runModifier, crouchModifier;
    Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Move(runModifier);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            cam.transform.position = transform.position + new Vector3(0, 0.1f, 0);
            Move(crouchModifier);
        }else
        {
            cam.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            Move(1);
        }
    }

    void Move(float modifier)
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * walkSpeed * modifier, rb.linearVelocity.y, moveInput.y * walkSpeed * modifier);
        rb.linearVelocity = transform.TransformDirection(playerVelocity);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
