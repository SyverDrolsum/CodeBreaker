using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public Transform[] spawnPoints;
    private bool isActive = false;
    private bool playerInRange = false;
  

    private void Update()
    {
        Debug.Log($"Player In Range: {playerInRange}, Lever Active: {isActive}");

        if (playerInRange && !isActive && Input.GetKeyDown(KeyCode.E))
        {
            ActivateLever();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered lever range.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited lever range.");
        }
    }

    private void ActivateLever()
    {
        isActive = true;
        Debug.Log("Lever activated! Platforms spawned.");

        if (platformPrefabs.Length != spawnPoints.Length)
        {
            Debug.LogError("Platform Prefabs and Spawn Points arrays do not match in length!");
            return;
        }

        for (int i = 0; i < platformPrefabs.Length && i < spawnPoints.Length; i++)
        {
            Instantiate(platformPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
           
        }
    }
}
