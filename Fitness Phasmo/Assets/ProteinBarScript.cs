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

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {
        Ghost = FindAnyObjectByType<Ghost>();

        EatenProteinBar.SetActive(false);
        WholeProteinBar.SetActive(true);
    }

    private void Update()
    {
       
    }

    IEnumerator GhostEatsProteinBar()
    {
        letsGo = true;
        float chance = Random.Range(0f, 1f);
        if (chance > 0.7f) // chancen er her brormand
        {
            EatenProteinBar.SetActive(true);
            WholeProteinBar.SetActive(false);
        }

        yield return new WaitForSeconds(5);
        letsGo = false;
    }

    public void OnTriggerStay(Collider other)
    {
        if (letsGo == false && other.gameObject == Ghost.Room)
        {
            if (Ghost.GhosteType.Clue1 == Clue || Ghost.GhosteType.Clue2 == Clue || Ghost.GhosteType.Clue3 == Clue)
            {
                StartCoroutine(GhostEatsProteinBar());
            }
        }
    }
}
