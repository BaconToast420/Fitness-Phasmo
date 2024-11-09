using System.Collections.Generic;
using UnityEngine;


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
    public List<GhostTypes> GhostTypesList;

    public GameObject Room;
    public List<GameObject> Rooms;

    public float GhostEventTimer;


    public PlayerMove Player;
    public bool HuntBegun;
    public GameObject Model;
    public float HuntTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Room = Rooms[Random.Range(0, Rooms.Count)];
        GhosteType = GhostTypesList[Random.Range(0, GhostTypesList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if (HuntBegun == false)
        {
            if (HuntTimer > 60)
            {
                HuntBegun = true;

                HuntTimer = 0;
            }
            else
            {
                HuntTimer += Time.deltaTime;
            }
        }
    }
}
