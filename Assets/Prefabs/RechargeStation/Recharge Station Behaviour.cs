using UnityEngine;

public class RechargeStationBehaviour : MonoBehaviour
{
    public Health health;
    [SerializeField] private AudioClip rechargeSound;
    private GameObject targetObject;

  
    //When Player touches rechargeStation, the station disappears and heals player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetObject = GameObject.FindGameObjectWithTag("Player");
            health = targetObject.GetComponent<Health>();
//            SoundManager.instance.PlaySound(rechargeSound);
            Destroy(gameObject);
            health.Heal(1);

        }
    }
}
