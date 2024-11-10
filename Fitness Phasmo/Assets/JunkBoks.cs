using System.Collections.Generic;
using UnityEngine;

public class JunkBoks : MonoBehaviour
{
    public List<AudioSource> sources;

    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 30)
        {
            sources[Random.Range(0, sources.Count)].Play();

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
