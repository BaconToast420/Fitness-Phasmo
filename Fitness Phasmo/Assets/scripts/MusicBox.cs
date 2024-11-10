using UnityEngine;

public class MusicBox : MonoBehaviour
{
    float distanceToPlayer;
    GameObject player;

    AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 2.5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
        }
    }
}
