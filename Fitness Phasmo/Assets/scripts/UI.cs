using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public Ghost GhostScript;

    public KeyCode toggleKey = KeyCode.J;

    public GameObject EvidenceSheet;

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

    public float lowOpacity = 0.5f;
    public float highOpacity = 1.0f;

    public void ToggleMirror()
    {
        if(MirrorBombToggle.GetComponent<Toggle>().isOn == true)
        {
            AllNaturalButton.GetComponent<TextMeshProUGUI>().color = Color.grey;
            BeginnerButton.GetComponent<TextMeshProUGUI>().color = Color.grey;
            OldManButton.GetComponent<TextMeshProUGUI>().color = Color.grey;
        }
    }

    public void ToggleHands()
    {

    }

    public void ToggleBar()
    { 

    }

    public void ToggleGrunts()
    {

    }

    public void ToggleSweat()
    {

    }

    public void ToggleWeights()
    {

    }

    void SetOpacity(bool isChecked)
    {
        /*Color textColor = .color;

        textColor.a = isChecked ? lowOpacity : highOpacity;

        t.color = textColor;*/
    }

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
