using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")] [SerializeField]
    private Image photoDisplayArea;

    [SerializeField] private GameObject Broski;
    
    private Texture2D screenCapture;
    private RenderTexture renderTexture;


    [SerializeField] GameObject playerPlayer;
    [SerializeField] private Camera photoCamera;

    private void Start()
    {
        // Initialize a RenderTexture with the dimensions you want for the photo
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        
        photoCamera.targetTexture = renderTexture;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Define the offset position behind the player (adjust as needed)
            Vector3 offset = new Vector3(0, 0, -2); // 2 units behind the player

            // Calculate the spawn position based on the player's position and rotation
            Vector3 spawnPosition = playerPlayer.transform.position + playerPlayer.transform.rotation * offset;
        
            // Instantiate Broski at the calculated position behind the player
            GameObject bro = Instantiate(Broski, spawnPosition, Quaternion.identity);
            
            StartCoroutine(CapturePhoto());
            
            // Wait for destroy
            Destroy(bro, 0.02f);
            Debug.Log("Photo capture triggered!");
        }
    }

    IEnumerator CapturePhoto()
    {
        yield return new WaitForEndOfFrame();
        
        // Render the photo camera's view into the render texture
        photoCamera.Render();

        // Set the render texture as the active render target to read from
        RenderTexture.active = renderTexture;
        
        // Read the pixels from the RenderTexture
        screenCapture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        screenCapture.Apply();
        
        // Reset the active render target
        RenderTexture.active = null;

        showPhoto();

        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        // Hide the photo display area to show the camera view again
        photoDisplayArea.gameObject.SetActive(false);
    }

    void showPhoto()
    {
        // Convert the Texture2D to a sprite and display it
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
        
        // Ensure the photo display area is active
        photoDisplayArea.gameObject.SetActive(true);
    }
}
