using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private Vector3 originalScale;
    public Vector3 pressedScale = new Vector3(0.9f, 0.9f, 1f);  // Scale when pressed

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // When the mouse is clicked, change the scale to show press effect
        transform.localScale = pressedScale;
    }

    private void OnMouseUp()
    {
        // Reset scale when mouse is released
        transform.localScale = originalScale;
    }

    public void PressButton() // Can be called from another script for keyboard input
    {
        // Change scale for visual effect
        transform.localScale = pressedScale;
        // Optionally add sound or animation here
    }

    public void ReleaseButton()
    {
        // Reset the scale to original size
        transform.localScale = originalScale;
    }
}
