using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HuntPostProcessing : MonoBehaviour
{
    public Ghost ghostScript;
    public GameObject ghosts;

    public float distortionIntensity = 0.3f;  // Fixed distortion intensity when hunting
    public float vignetteSmoothness = 1.0f;   // Smoothness of vignette effect

    private Volume volume;
    private ChromaticAberration chromaticAberration;
    private LensDistortion lensDistortion;
    private Vignette vignette;

    private void Start()
    {
        ghostScript = ghosts.GetComponent<Ghost>();
        
        // Get the volume component
        volume = GetComponent<Volume>();

        // Access Chromatic Aberration, Lens Distortion, and Vignette settings
        if (volume.profile.TryGet(out chromaticAberration) &&
            volume.profile.TryGet(out lensDistortion) &&
            volume.profile.TryGet(out vignette))
        {
            chromaticAberration.intensity.value = 0f;
            lensDistortion.intensity.value = 0f;
            vignette.smoothness.value = 0f;  // Start vignette smoothness at 0
        }
        else
        {
            Debug.LogError("Ensure that Chromatic Aberration, Lens Distortion, and Vignette are added to the Volume Profile.");
        }
    }

    private void Update()
    {
        if (ghostScript.HuntBegun)
        {
            // Set Chromatic Aberration intensity to 1
            chromaticAberration.intensity.value = 1.0f;

            // Set Lens Distortion to a fixed intensity
            lensDistortion.intensity.value = distortionIntensity;

            // Set Vignette smoothness to 1
            vignette.smoothness.value = vignetteSmoothness;
        }
        else
        {
            // Reset effects when Hunt is false
            chromaticAberration.intensity.value = 0f;
            lensDistortion.intensity.value = 0f;
            vignette.smoothness.value = 0f;
        }
    }
}