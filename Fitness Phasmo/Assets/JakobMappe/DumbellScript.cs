using UnityEngine;

public class DumbellScript : MonoBehaviour
{
    Rigidbody rb;
    public bool doThing = false;
    public Vector3 forceVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(doThing == true)
        {
            doThing = false;
            rb.AddForce(forceVector, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            doThing = true;
        }
    }
}
