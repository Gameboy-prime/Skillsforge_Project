using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrameRate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fpsDisplay;  // UI Text element to display the FPS
    private float deltaTime = 0.0f;

    void Update()
    {
        // Calculate the time passed between frames
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        // Calculate the FPS
        float fps = 1.0f / deltaTime;

        // Update the UI Text element with the FPS value
        if (fpsDisplay != null && Time.timeScale !=0)
        {
            fpsDisplay.text = Mathf.Ceil(fps).ToString();
        }
    }
}
