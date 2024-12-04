using UnityEngine;



public class CheckPoint : MonoBehaviour
{
    public Health health;

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SaveSystem.SaveCheckpoint(other.transform.position, health.currentHealth);
            Debug.Log("Checkpoint saved!");
        }
    }
}
