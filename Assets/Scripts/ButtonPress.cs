using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private Vector3 originalScale;
    public Vector3 pressedScale = new Vector3(0.6f, 0.25f, 1f);  // Scale when pressed
    public GameObject shutter;  // Reference to the shutter to open
    private ShutterController shutterController;

    void Start()
    {
        //store original scale
        originalScale = transform.localScale;

        // Get the ShutterController component from the shutter object
        if (shutter != null)
        {
            shutterController = shutter.GetComponent<ShutterController>();
        }
    }

private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            transform.localScale = pressedScale;

            shutterController.OpenShutter();
        }
    }

private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.localScale = originalScale;

            shutterController.CloseShutter();
        }
    }
}
