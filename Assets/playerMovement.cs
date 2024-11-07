using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public ButtonPress buttonPress; // Reference to the button press script

    void Start()
    {
        
    }

  
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Rigidbody2D.velocity = new Vector2(moveInput * moveSpeed, Rigidbody2D.velocity.y);

        // Check for the button press using the keyboard (e.g., the "E" key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            buttonPress.PressButton();
        }

        // Optionally, you can check for the key release to reset the button
        if (Input.GetKeyUp(KeyCode.E))
        {
            buttonPress.ReleaseButton();
        }
    }
}
