using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    public static int collectableCount = 0;
    
    //When Player touches collectable, the collectable disappears and the collectableCounter goes up by one
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collectableCount++;
            Destroy(gameObject);
        }
    }
}
