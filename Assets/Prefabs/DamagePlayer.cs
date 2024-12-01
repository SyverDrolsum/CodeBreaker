using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public CapsuleCollider2D virusDamage;
    public Health health;
   
    //When touching player, player take damage
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("MedPlayer")||collision.gameObject.CompareTag("SmallPlayer"))
        {
           health.TakeDamage(1);
        }
    }
}
