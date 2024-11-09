using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject EvidenceSheet;

    public KeyCode toggleKey = KeyCode.J;

    public GameObject MirrorBombToggle;
    public GameObject HandPrintsToggle;
    public GameObject ProteinBarToggle;
    public GameObject GruntsToggle;
    public GameObject SweatPuddlesToggle;
    public GameObject WeightThrowToggle;

    public GameObject SteroidFreakButton;
    public GameObject AllNaturalButton;
    public GameObject OldManButton;
    public GameObject InfluencerButton;
    public GameObject BeginnerButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            EvidenceSheet.SetActive(!EvidenceSheet.activeSelf);
        }
    }
}
