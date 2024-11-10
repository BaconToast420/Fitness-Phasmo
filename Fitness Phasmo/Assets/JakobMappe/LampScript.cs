using System.Collections;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    [SerializeField] GameObject lampLight;
    [SerializeField] Material lightMat;
    float timeDelay;
    bool isFlickering;

    void Start()
    {
        
    }

    void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(flickerLight());
        }
    }

    IEnumerator flickerLight()
    {
        isFlickering = true;
        lampLight.SetActive(false);
        lightMat.DisableKeyword("_EMISSION");
        timeDelay = Random.Range(0.2f, 1f);
        yield return new WaitForSeconds(timeDelay);
        lampLight.SetActive(true);
        timeDelay = Random.Range(0.1f, 1f);
        lightMat.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
