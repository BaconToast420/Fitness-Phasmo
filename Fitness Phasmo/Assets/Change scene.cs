using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene : MonoBehaviour
{
    [SerializeField] 
    private string mainSceneName = "Main Scene";  // Name of your main scene

    // Change to the main scene
    public void ChangeScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
