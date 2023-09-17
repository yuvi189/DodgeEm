using UnityEngine;
using UnityEngine.UI;

public class playerCollision : MonoBehaviour
{
    public Material changedWallMaterial; // Assign the material for the changed wall texture.
    public Text popupText;  // Assign a UI Text component for the popup.
    public AudioClip collisionSound;    // Assign the sound effect AudioClip.

    private bool isShowingPopup = false;
    private float popupDuration = 0.5f;
    private float popupTimer = 0.0f;

    private void Update()
    {
        if (isShowingPopup)
        {
            // If the popup is currently shown, increment the timer.
            popupTimer += Time.deltaTime;

            if (popupTimer >= popupDuration)
            {
                // If the timer exceeds the desired duration, hide the popup.
                popupText.gameObject.SetActive(false);
                isShowingPopup = false;
                popupTimer = 0.0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Change the wall's material.
            Renderer wallRenderer = collision.gameObject.GetComponent<Renderer>();
            if (wallRenderer != null)
            {
                wallRenderer.material = changedWallMaterial;
            }

            // Show a temporary popup with some text.
            ShowPopup("Wall Collision!");

            // Play the collision sound effect.
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }

    private void ShowPopup(string message)
    {
        if (popupText != null && !isShowingPopup)
        {
            // Set the popup text.
            popupText.text = message;

            // Show the popup.
            popupText.gameObject.SetActive(true);

            // Start the timer.
            isShowingPopup = true;
        }
    }
}
