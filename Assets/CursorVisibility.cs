using UnityEngine;

public class CursorVisibility : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
    }

  
}
