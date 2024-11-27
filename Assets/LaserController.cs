using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
    public GameObject laserSprite; // The sprite for the laser
    public float onDuration = 2f;  // Time the laser is on
    public float offDuration = 2f; // Time the laser is off

    private bool isLaserOn = false;

    void Start()
    {
        StartCoroutine(ToggleLaser());
    }


    private IEnumerator ToggleLaser()
    {
        while (true)
        {
            // Toggle laser state
            isLaserOn = !isLaserOn;
            laserSprite.SetActive(isLaserOn);
            Debug.Log($"Laser is now {(isLaserOn ? "ON" : "OFF")}");

            // Wait for the duration depending on the state
            yield return new WaitForSeconds(isLaserOn ? onDuration : offDuration);
        }
    }

    //if player gets hit
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isLaserOn)
        {
            Debug.Log("Player hit by laser!");
        }
    }
}
