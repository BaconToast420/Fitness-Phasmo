using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProteinBarScript : MonoBehaviour
{
    
    public GameObject EatenProteinBar;
    public GameObject WholeProteinBar;
    public bool letsGo = false;
    public bool evidence = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    

    private void Update()
    {
        if (letsGo == false && evidence == true)
        {
            StartCoroutine(GhostEatsProteinBar());
        }
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

}
