using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


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

    public int HandNumber;
    public GameObject Hand;


    public Camera Camera; 
    public LayerMask ToolLayer;

    public Image MiddleSceneImage;
    public Sprite DefultIcon;
    public Sprite PickUpIcon;
    public Sprite LickIcon;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HandNumber = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HandNumber = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HandNumber = 3;
        }


        if (HandNumber == 1)
        {
            if (Tool1Object != null)
            {
                Tool1Object.SetActive(true);
            }

            if (Tool2Object != null)
            {
                Tool2Object.SetActive(false);
            }

            if (Tool3Object != null)
            {
                Tool3Object.SetActive(false);
            }
        }

        if (HandNumber == 2)
        {
            if (Tool1Object != null)
            {
                Tool1Object.SetActive(false);
            }

            if (Tool2Object != null)
            {
                Tool2Object.SetActive(true);
            }

            if (Tool3Object != null)
            {
                Tool3Object.SetActive(false);
            }
        }

        if (HandNumber == 3)
        {
            if (Tool1Object != null)
            {
                Tool1Object.SetActive(false);
            }

            if (Tool2Object != null)
            {
                Tool2Object.SetActive(false);
            }

            if (Tool3Object != null)
            {
                Tool3Object.SetActive(true);
            }
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


        // Create a ray from the center of the camera's view
        Ray ray = Camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        // Perform the raycast
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ToolLayer))
        {
            if (Vector3.Distance(hit.transform.position, transform.position) < 7)
            {
                MiddleSceneImage.sprite = PickUpIcon;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Tool1Object == null)
                    {
                        Tool1Object = hit.transform.gameObject;
                        Tool1Object.SetActive(false);
                        Tool1Object.transform.parent = Hand.transform;
                        Tool1Object.transform.position = Hand.transform.position;
                        Tool1Object.transform.rotation = Hand.transform.rotation;
                        Tool1Object.GetComponent<Rigidbody>().isKinematic = true;
                        Tool1Object.GetComponent<BoxCollider>().enabled = false;
                    }
                    else if (Tool2Object == null)
                    {
                        Tool2Object = hit.transform.gameObject;
                        Tool2Object.SetActive(false);
                        Tool2Object.transform.parent = Hand.transform;
                        Tool2Object.transform.position = Hand.transform.position;
                        Tool2Object.transform.rotation = Hand.transform.rotation;
                        Tool2Object.GetComponent<Rigidbody>().isKinematic = true;
                        Tool2Object.GetComponent<BoxCollider>().enabled = false;
                    }
                    else
                    {
                        Tool3Object = hit.transform.gameObject;
                        Tool3Object.SetActive(false);
                        Tool3Object.transform.parent = Hand.transform;
                        Tool3Object.transform.position = Hand.transform.position;
                        Tool3Object.transform.rotation = Hand.transform.rotation;
                        Tool3Object.GetComponent<Rigidbody>().isKinematic = true;
                        Tool3Object.GetComponent<BoxCollider>().enabled = false;
                    }
                }
            }
            else
            {
                MiddleSceneImage.sprite = DefultIcon;
            }
        }
        else
        {
            MiddleSceneImage.sprite = DefultIcon;
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
