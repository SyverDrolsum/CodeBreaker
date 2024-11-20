using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    public static int collectableCount = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collectableCount++;
            Destroy(gameObject);
        }
    }
}
