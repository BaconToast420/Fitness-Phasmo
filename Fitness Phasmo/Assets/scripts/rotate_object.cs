using System.Collections;
using UnityEngine;

public class rotate_object : MonoBehaviour
{
public GameObject ToRotate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float rotationSpeed = 10f; // Rotation speed in degrees per second
    public float targetAngle = 90f; // Target angle in degrees along the y-axis
    private Quaternion originalRotation;

    private bool isRotating = false; // Prevents multiple coroutine starts

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalRotation = ToRotate.transform.rotation;
       /* if (ToRotate != null)
        {
            StartCoroutine(RotateToTargetAngle());
        }*/
    }

    public void open()
    {
        StartCoroutine(RotateToTargetAngle());
    }

    public void close()
    {
        StartCoroutine(ReturnToOriginalRotation());
    }
    // Coroutine to rotate object to the specified angle
    private IEnumerator RotateToTargetAngle()
    {
        isRotating = true;
        Quaternion startRotation = ToRotate.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, targetAngle, 0);

        while (Quaternion.Angle(ToRotate.transform.rotation, endRotation) > 0.1f)
        {
            ToRotate.transform.rotation = Quaternion.RotateTowards(
                ToRotate.transform.rotation,
                endRotation,
                rotationSpeed * Time.deltaTime
            );
            yield return null; // Wait for the next frame
        }

        ToRotate.transform.rotation = endRotation; // Ensure exact final rotation
        isRotating = false;
    }
    
    private IEnumerator ReturnToOriginalRotation()
    {
        // Wait until rotation to the target angle is complete
        while (isRotating)
        {
            yield return null;
        }

        isRotating = true;
        while (Quaternion.Angle(ToRotate.transform.rotation, originalRotation) > 0.1f)
        {
            ToRotate.transform.rotation = Quaternion.RotateTowards(
                ToRotate.transform.rotation,
                originalRotation,
                rotationSpeed * Time.deltaTime
            );
            yield return null; // Wait for the next frame
        }

        ToRotate.transform.rotation = originalRotation; // Ensure exact final rotation
        isRotating = false;
    }
}
