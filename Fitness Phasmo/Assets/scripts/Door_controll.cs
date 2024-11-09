using System;
using UnityEngine;

public class Door_controll : MonoBehaviour
{
    public rotate_object leftDoor;
    public rotate_object rightDoor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //leftDoor.open();
        //rightDoor.open();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leftDoor.open();
            rightDoor.open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leftDoor.close();
            rightDoor.close();
        }
    }


}
