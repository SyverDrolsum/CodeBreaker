using UnityEngine;
using UnityEngine.Events;

public class DamagePlayer : MonoBehaviour
{
    public Health health;
    private GameObject targetObject;

    public UnityEvent<GameObject> onDamagedBy;

    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player");
        health = targetObject.GetComponent<Health>();
    }

    //When touching player, player take damage
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(1);
            onDamagedBy?.Invoke(gameObject);
        }
    }
}
