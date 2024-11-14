using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject[] platformsToSpawn;
    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            ActivateLever();
        }
    }

    private void ActivateLever()
    {
        isActive = true;

        foreach (GameObject platform in platformsToSpawn)
        {
            platform.SetActive(true);
        }

    }


 
}
