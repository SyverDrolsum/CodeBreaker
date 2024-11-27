using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;

    [SerializeField]
    private float padding = 0.5f; // Extra space to prevent clipping

    void Start()
    {
        mainCamera = Camera.main;
        UpdateScreenBounds();
    }

    void LateUpdate()
    {
        Vector3 viewPosition = transform.position;

        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x + padding, screenBounds.y - padding);
        transform.position = viewPosition;
    }

    void UpdateScreenBounds()
    {
        // Get the world space bounds of the camera view
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z));

        screenBounds = new Vector2(bottomLeft.x, topRight.x);
    }
}

