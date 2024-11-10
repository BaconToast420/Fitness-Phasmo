using UnityEngine;

public class GemmeSted : MonoBehaviour
{
    public PlayerMove PlayerMove;

    public void OnTriggerEnter(Collider other)
    {
        PlayerMove.Gemmer = true;
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerMove.Gemmer = false;
    }
}
