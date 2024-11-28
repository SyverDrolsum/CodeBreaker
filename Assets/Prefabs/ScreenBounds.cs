using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private Camera mainCamera;      //reference to the main camera
    private Vector2 screenBounds;       //horizontal bounds of the screen

    [SerializeField]
    private float padding = 0.5f; // Extra space to prevent player to touch end of screen

    void Start()
    {
        mainCamera = Camera.main;
        UpdateScreenBounds();       //calculate screen bounds
    }

    void LateUpdate()
    {
        Vector3 viewPosition = transform.position;      //get objects cuttent position

        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x + padding, screenBounds.y - padding);       //clamp objects position within the screen bounds
        transform.position = viewPosition;
    }

    void UpdateScreenBounds()
    {
        //get the world space bounds of the camera view
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z));

        screenBounds = new Vector2(bottomLeft.x, topRight.x);       //store the horizontal bounds
    }
}

