using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public enum ToolType {None, Flashlight, UVLight}

[System.Serializable]
public class Tool
{
    public string Name;
    public string Beskrivelse;

    public ToolType Type;
}

public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject cam;

    Rigidbody rb;
    [SerializeField] float walkSpeed, runModifier, crouchModifier;
    Vector2 moveInput;

    public GameObject FlashLight;

    public GameObject Tool1Object;
    public GameObject Tool2Object;
    public GameObject Tool3Object;

    public Tool Tool1Tool;
    public Tool Tool2Tool;
    public Tool Tool3Tool;

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



        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Tool1Tool.Type == ToolType.Flashlight || Tool2Tool.Type == ToolType.Flashlight || Tool3Tool.Type == ToolType.Flashlight)
            {
                if (FlashLight.active == true)
                {
                    FlashLight.SetActive(false);
                }
                else
                {
                    FlashLight.SetActive(true);
                }
            }
        }

        if (Tool1Tool.Type != ToolType.Flashlight && Tool2Tool.Type != ToolType.Flashlight && Tool3Tool.Type != ToolType.Flashlight)
        {
            FlashLight.SetActive(false);
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
