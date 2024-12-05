using System;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    public static event Action<CollectableBehaviour> OnCollected;

    public static int collectableCount = 0;
    [SerializeField] private AudioClip collectableSound;

    private string collectableID; // Unique ID for this collectable

    private void Start()
    {
        // Assign a unique ID for the collectable based on its name and position
        collectableID = $"{gameObject.name}_{transform.position.x}_{transform.position.y}";

        // Check if this collectable has already been collected
        if (PlayerPrefs.GetInt(collectableID, 0) == 1)
        {
            Destroy(gameObject); // Remove it from the scene if already collected
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(collectableSound);

            // Mark the collectable as collected
            collectableCount++;
            PlayerPrefs.SetInt(collectableID, 1); // Save the collected state
            PlayerPrefs.Save();

            OnCollected?.Invoke(this);

            // Destroy the collectable
            Destroy(gameObject);
        }
    }
}
