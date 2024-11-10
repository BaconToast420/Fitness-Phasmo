using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")] [SerializeField]
    private Image photoDisplayArea;
    public bool photoDisplayGoAway;
    public float photoDisplayGoAwayTimer;

    [SerializeField] private GameObject Broski;
    public Ghost Ghost;
    
    private Texture2D screenCapture;
    private RenderTexture renderTexture;


    [SerializeField] GameObject playerPlayer;
    [SerializeField] private Camera photoCamera;


    public AudioSource BilledTagningAudio;

    private void Start()
    {
        // Initialize a RenderTexture with the dimensions you want for the photo
        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        
        photoCamera.targetTexture = renderTexture;
    }

    public void Update()
    {
        if (photoDisplayGoAway == true)
        {
            if (photoDisplayGoAwayTimer > 3)
            {
                photoDisplayArea.gameObject.SetActive(false);
                photoDisplayGoAway = false;
            }
            else
            {
                photoDisplayGoAwayTimer += Time.deltaTime;
            }
        }
    }

    public void Pressed()
    {
        BilledTagningAudio.Play();

        photoDisplayGoAwayTimer = 2;

        // Define the offset position behind the player (adjust as needed)
        Vector3 offset = new Vector3(0, 0, -2); // 2 units behind the player

        // Calculate the spawn position based on the player's position and rotation
        Vector3 spawnPosition = playerPlayer.transform.position + playerPlayer.transform.rotation * offset;

        if (Ghost.GhosteType.Clue1 == Clues.Photobomb || Ghost.GhosteType.Clue2 == Clues.Photobomb || Ghost.GhosteType.Clue3 == Clues.Photobomb)
        {
            // Instantiate Broski at the calculated position behind the player
            GameObject bro = Instantiate(Broski, spawnPosition, Quaternion.identity);

            Debug.Log("Broski");

            Destroy(bro, 0.02f);
        }

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

        photoDisplayGoAway = true;

        // Wait for destroy
        
        Debug.Log("Photo capture triggered!");
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
