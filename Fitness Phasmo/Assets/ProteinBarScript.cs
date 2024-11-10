    using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProteinBarScript : MonoBehaviour
{
    public Clues Clue;

    public GameObject EatenProteinBar;
    public GameObject WholeProteinBar;

    public Ghost Ghost;

    public bool letsGo;

    public float Timer;

    public AudioSource AudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {
        Ghost = FindAnyObjectByType<Ghost>();

        EatenProteinBar.SetActive(false);
        WholeProteinBar.SetActive(true);
    }

    private void Update()
    {
        if (letsGo == true)
        {
            if (Timer > 5)
            {
                float chance = Random.Range(0f, 1f);
                if (chance > 0.7f) // chancen er her brormand
                {
                    EatenProteinBar.SetActive(true);
                    WholeProteinBar.SetActive(false);

                    AudioSource.Play();
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
