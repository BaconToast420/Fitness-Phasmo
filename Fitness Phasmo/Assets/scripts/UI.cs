using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public string Name;

    public Ghost GhostScript;
    public List<GhostTypes> GhostTypesList;

    public KeyCode toggleKey = KeyCode.J;

    public GameObject EvidenceSheet;

    public bool MirrorBombToggle;
    public bool HandPrintsToggle;
    public bool ProteinBarToggle;
    public bool GruntsToggle;
    public bool SweatPuddlesToggle;
    public bool WeightThrowToggle;

    public GameObject SteroidFreakButton;
    public GameObject AllNaturalButton;
    public GameObject OldManButton;
    public GameObject InfluencerButton;
    public GameObject BeginnerButton;

    public List<GameObject> CheckMarks;

    public float lowOpacity = 0.5f;
    public float highOpacity = 1.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GhostScript = FindAnyObjectByType<Ghost>();

        GhostScript.GhosteType = GhostTypesList[Random.Range(0, GhostTypesList.Count)];
    }

    public void ToggleMirror()
    {
        MirrorBombToggle = !MirrorBombToggle;
        UpdateGhost();
    }

    public void ToggleHands()
    {
        HandPrintsToggle = !HandPrintsToggle;
        UpdateGhost();
    }

    public void ToggleBar()
    {
        ProteinBarToggle = !ProteinBarToggle;
        UpdateGhost();
    }

    public void ToggleGrunts()
    {
        GruntsToggle = !GruntsToggle;
        UpdateGhost();
    }

    public void ToggleSweat()
    {
        SweatPuddlesToggle = !SweatPuddlesToggle;
        UpdateGhost();
    }

    public void ToggleWeights()
    {
        WeightThrowToggle = !WeightThrowToggle;
        UpdateGhost();
    }

 
    public void UpdateGhost()
    {
        SteroidFreakButton.SetActive(true);
        AllNaturalButton.SetActive(true);
        BeginnerButton.SetActive(true);
        OldManButton.SetActive(true);
        InfluencerButton.SetActive(true);

        if (MirrorBombToggle == true)
        {
            AllNaturalButton.SetActive(false);
            BeginnerButton.SetActive(false);
            OldManButton.SetActive(false);
        }

        if (HandPrintsToggle == true)
        {
            BeginnerButton.SetActive(false);
            InfluencerButton.SetActive(false);
        }

        if (ProteinBarToggle == true)
        {
            SteroidFreakButton.SetActive(false);
            BeginnerButton.SetActive(false);
            OldManButton.SetActive(false);
        }

        if (GruntsToggle == true)
        {
            SteroidFreakButton.SetActive(false);
            AllNaturalButton.SetActive(false);
        }

        if (SweatPuddlesToggle == true)
        {
            SteroidFreakButton.SetActive(false);
            InfluencerButton.SetActive(false);
        }

        if (WeightThrowToggle == true)
        {
            AllNaturalButton.SetActive(false);
            OldManButton.SetActive(false);
            InfluencerButton.SetActive(false);
        }
    }


    public void ToggelAllOff(GameObject Checkmark)
    {
        foreach (var item in CheckMarks)
        {
            item.SetActive(false);
        }

        Checkmark.SetActive(true);
    }

    public void ToggelAllOffName(string _name)
    {
        Name = _name;
    }
}
