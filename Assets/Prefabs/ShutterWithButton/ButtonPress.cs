using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private Vector3 originalScale;      //store buttons original scale
    public Vector3 pressedScale = new Vector3(0.6f, 0.25f, 1f);  // Scale when pressed
    public GameObject shutter;  // Reference to the shutter to open
    private ShutterController shutterController;        //reference to the script attached to the shutter
  //  public float shutterCloseDelay = 3f;

    [SerializeField] private AudioClip buttonSound;

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

    //check if player has entered buttons trigger zone
private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            transform.localScale = pressedScale;        //change buttons scale 
            SoundManager.instance.PlaySound(buttonSound);
            shutterController.OpenShutter();        //open shutter using the ShutterController
        }
    }

    //check if player has exited buttons trigger zone
private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.localScale = originalScale;       //reset button to original scale

           // Invoke(nameof(shutterController.CloseShutter), shutterCloseDelay);

            //shutterController.CloseShutter();       //close shutter
        }
    }
}
