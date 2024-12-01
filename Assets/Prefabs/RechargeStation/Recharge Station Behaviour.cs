using UnityEngine;

public class RechargeStationBehaviour : MonoBehaviour
{
    public Health health;
  
    //When Player touches rechargeStation, the station disappears and heals player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            health.Heal(1);

        }
    }
}
