using System.Collections;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]float activateDistance, reactivateTimer, rotateSpeed;
    float distanceToPlayer, rotationCounter;
    GameObject player;
    [SerializeField] GameObject door;

    bool isRotating = false;
    bool isOpen = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotationCounter = 0;
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(distanceToPlayer);

        if (isRotating == true)
        {
            if(isOpen == true)
            {
                transform.Rotate(0, -1 * rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, 1 * rotateSpeed * Time.deltaTime, 0);
            }

            rotationCounter += Mathf.Abs(1 * rotateSpeed * Time.deltaTime);

            
            //Debug.Log(rotationCounter);

            if (rotationCounter > 90)
            {
                isRotating = false;
                rotationCounter = 0;
                isOpen = !isOpen;
            }
        }
        else if (isRotating == false)
        { 
            if(distanceToPlayer < activateDistance)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(DisableCollider());
                }
            }
        }
    }

    IEnumerator DisableCollider()
    {
        door.GetComponent<Collider>().enabled = false;
        isRotating = true;
        //Debug.Log("Collider deactivated!");

        yield return new WaitForSeconds(reactivateTimer);

        door.GetComponent<Collider>().enabled = true;
        //Debug.Log("Collider activated!");
    }
}
