using UnityEngine;

public class ShutterController : MonoBehaviour
{

    public Vector3 openPosition; // Position where the shutter should move to when opened
    public float openSpeed = 2f;    //speed shutter opens and closes
    public float openHeight = 2f;   //height the shutter moves to
    public float closeDelay = 2f; //seconds before shutter closes

    //shutters movement state
    private bool isOpening = false;
    private bool isClosing = false;

    private Vector3 closedPosition; //shutter position when closed

    void Start()
    {
        closedPosition = transform.position;     // store the initial (closed) position of the shutter

        openPosition = closedPosition + new Vector3(0, openHeight, 0);      //calculate open position based on closed position and open height
    }

    void Update()
    {
        //if the shutter is opening, move it toward the open position
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);

            //stop opening once it reaches the open position
            if (transform.position == openPosition)
            {
                isOpening = false;
                Invoke("CloseShutter", closeDelay);
            }
        }

        //if shutter is closing, move it toward the close position 
        else if (isClosing)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, openSpeed * Time.deltaTime);

            if (transform.position == closedPosition)
            {
                isClosing = false;
            }
        }

    }

        //method to open shutter
        public void OpenShutter()
        {
            isOpening = true;
            isClosing = false;
        }

        //method to close shutter
        public void CloseShutter()
        {
            isClosing = true;
            isOpening = false;
        }
    

}
