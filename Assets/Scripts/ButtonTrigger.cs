using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public ShutterController shutterController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with the button
        if (other.CompareTag("Player"))
        {
            // Open the shutter
            shutterController.OpenShutter();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
