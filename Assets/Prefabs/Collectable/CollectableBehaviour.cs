using System;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    public static event Action<CollectableBehaviour> OnCollected;

    public static int collectableCount = 0;
    [SerializeField] private AudioClip collectableSound;


    //When Player touches collectable, the collectable disappears and the collectableCounter goes up by one
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(collectableSound);
            collectableCount++;
            OnCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
