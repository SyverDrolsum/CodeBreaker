using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Health health;
   
    //When touching player, player take damage
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           health.TakeDamage(1);
        }
    }
}
