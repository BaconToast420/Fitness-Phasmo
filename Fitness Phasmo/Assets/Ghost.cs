using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum Clues { Photobomb, Handprint, Proteinbar, Sus, Sweat, WeightThrowing }

[System.Serializable]
public class GhostTypes
{
    public string Name;

    public Clues Clue1;
    public Clues Clue2;
    public Clues Clue3;
}

public class Ghost : MonoBehaviour
{
    public GhostTypes GhosteType;

    public GameObject Room;
    public List<GameObject> Rooms;

    public float GhostEventTimer;


    public PlayerMove Player;
    public bool HuntBegun;
    public GameObject Model;
    public float HuntTimer;
    public float HuntWait;
    public float StopHunting;

    public NavMeshAgent Agent;

    public GameObject GameOverScreen;

    public GameObject SweatPrefab;

    public List<AudioSource> Hount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();

        Room = Rooms[Random.Range(0, Rooms.Count)];
        transform.position = Room.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (HuntBegun == false)
        {
            if (GhostEventTimer > 45)
            {
                int _rr = Random.Range(0, 100);

                if (_rr > 70)
                {
                    if (GhosteType.Clue1 == Clues.Sweat || GhosteType.Clue2 == Clues.Sweat || GhosteType.Clue3 == Clues.Sweat)
                    {
                       GameObject gm = Instantiate(SweatPrefab, new Vector3(Room.transform.position.x + (Random.Range(-5, 5)), 0, Room.transform.position.z + (Random.Range(-5, 5))), transform.rotation);

                        Player.SweatStains.Add(gm);

                        if (Player.UVLight.active == true)
                        {
                            gm.SetActive(true);
                        }
                        else
                        {
                            gm.SetActive(false);
                        }
                    }
                }

                GhostEventTimer = 0;
            }
            else
            {
                GhostEventTimer += Time.deltaTime;
            }


            Model.SetActive(false);

            if (HuntTimer > 60)
            {
                int _rr = Random.Range(0, 100);

                if (_rr > 20 + Player.Sanity)
                {
                    HuntBegun = true;

                    foreach (var item in Hount)
                    {
                        item.Play();
                    }
                }

                HuntTimer = 0;
            }
            else
            {
                HuntTimer += Time.deltaTime;
            }
        }

        if (HuntBegun == true)
        {
            if (HuntWait > 10)
            {
                Model.SetActive(true);

                if (Player.Gemmer == false)
                {
                    Agent.destination = Player.gameObject.transform.position;
                }
                else
                {
                    Agent.destination = transform.position;
                }

                if (Vector3.Distance(Player.gameObject.transform.position, transform.position) < 3)
                {
                    GameOverScreen.SetActive(true);
                }

                if (StopHunting > 40)
                {
                    HuntBegun = false;
                    HuntWait = 0;
                    StopHunting = 0;

                    Model.SetActive(false);

                    foreach (var item in Hount)
                    {
                        item.Stop();
                    }
                }
                else
                {
                    StopHunting += Time.deltaTime;
                }
            }
            else
            {
                HuntWait += Time.deltaTime;
            }
        }
    }
}
