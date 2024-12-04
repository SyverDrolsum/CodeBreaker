using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public CapsuleCollider2D virusDamage;
    public Health health;
    public GameObject playerObject;

    void Start()
    {
        health = playerObject.GetComponent<Health>();
    }
   
    //When touching player, player take damage
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           health.TakeDamage(1);
        }
    }
}
