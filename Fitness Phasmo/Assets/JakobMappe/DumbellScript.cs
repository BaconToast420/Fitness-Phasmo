using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class DumbellScript : MonoBehaviour
{
    public Clues Clue;

    Rigidbody rb;

    public Ghost Ghost;

    public bool letsGo;

    public float Timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Ghost = FindAnyObjectByType<Ghost>();
    }

    void Update()
    {
        if (letsGo == true)
        {
            if (Timer > 5)
            {
                float chance = Random.Range(0f, 1f);
                if (chance > 0.7f) // chancen er her brormand
                {
                    Vector3 forceVector = new Vector3(Random.Range(-800, 800), Random.Range(200, 800), Random.Range(-800, 800));
                    rb.AddForce(forceVector, ForceMode.Impulse);
                }

                Timer = 0;
                letsGo = false;
            }
            else
            {
                Timer += Time.deltaTime;
            }
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (letsGo == false && other.gameObject == Ghost.Room)
        {
            if (Ghost.GhosteType.Clue1 == Clue || Ghost.GhosteType.Clue2 == Clue || Ghost.GhosteType.Clue3 == Clue)
            {
                letsGo = true;
            }
        }
    }
}
