using UnityEngine;

public class ButtonTrap : MonoBehaviour
{
    public GameObject trap;
    private ShutterController shutterController;

    private bool playerInRange = false;

    void Start()
    {
        if (trap != null)
        {
            shutterController = trap.GetComponent<ShutterController>();
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shutterController.OpenShutter();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

 


}
