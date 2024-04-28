using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCodigo : MonoBehaviour
{
    public Image fadeImage; // Reference to a UI Image component used for the fade effect
    public float fadeDuration = 1f; // Duration of the fade effect
    private bool isFading = false; // Flag to track if fade effect is in progress
    private float fadeTimer = 0f; // Timer to track the progress of the fade effect

    private void Start()
    {
        fadeImage.gameObject.SetActive(true); // Make sure the fade image is active at the start
        fadeImage.color = Color.black; // Set the initial color of the fade image to black
        StartFadeIn(); // Start the fade-in effect when the scene begins
    }

    private void Update()
    {
        if (isFading)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);

            fadeImage.color = new Color(0f, 0f, 0f, alpha); // Update the alpha value of the fade image

            if (fadeTimer >= fadeDuration)
            {
                isFading = false;
                fadeImage.gameObject.SetActive(false); // Disable the fade image after the fade-out effect
            }
        }
    }

    public void StartFadeIn()
    {
        fadeImage.gameObject.SetActive(true); // Enable the fade image
        fadeTimer = 0f;
        isFading = true;
    }

    public void StartFadeOut()
    {
        fadeImage.gameObject.SetActive(true); // Enable the fade image
        fadeImage.color = new Color(0f, 0f, 0f, 0f); // Set the initial color of the fade image to transparent
        fadeTimer = 0f;
        isFading = true;
    }
}