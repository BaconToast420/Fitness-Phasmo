using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public UI UI;

    public TMP_Text RightGhost;
    public TMP_Text YourGuess;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        // Get the active scene's name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void Done()
    {
        RightGhost.text = "The Ghost was a " + UI.GhostScript.GhosteType.Name + "";
        YourGuess.text = "You guessed " + UI.Name + "";
    }
}
