using UnityEngine;

public class ShutterController : MonoBehaviour
{

    public Vector3 openPosition; // Position where the shutter should move to when opened
    public float openSpeed = 2f;
    public float openHeight = 2f;
    public float closeDelay = 2f; //seconds before shutter closes
    private bool isOpening = false;
    private bool isClosing = false;

    private Vector3 closedPosition;

    void Start()
    {
        // Record the initial (closed) position of the shutter
        closedPosition = transform.position;

        openPosition = closedPosition + new Vector3(0, openHeight, 0);
    }

    void Update()
    {
        // If the shutter is opening, move it toward the open position
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);

            // Stop opening once it reaches the open position
            if (transform.position == openPosition)
            {
                isOpening = false;
                Invoke("CloseShutter", closeDelay);
            }
        }

        else if (isClosing)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, openSpeed * Time.deltaTime);

            if (transform.position == closedPosition)
            {
                isClosing = false;
            }
        }

    }

        public void OpenShutter()
        {
            isOpening = true;
            isClosing = false;
        }

        public void CloseShutter()
        {
            isClosing = true;
            isOpening = false;
        }
    

}
