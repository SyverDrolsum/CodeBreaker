using UnityEngine;
using UnityEngine.Events;

public class RechargeStationBehaviour : MonoBehaviour
{
    public Health health;
    [SerializeField] private AudioClip rechargeSound;
    private GameObject targetObject;
    private bool is_active = true;

    public UnityEvent onPlayerRecharge;
  
    //When Player touches rechargeStation, the station turns off and heals player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && is_active == true)
        {
            targetObject = GameObject.FindGameObjectWithTag("Player");
            health = targetObject.GetComponent<Health>();
            SoundManager.instance.PlaySound(rechargeSound);
            RemoveAllLights(gameObject);
            is_active = false;
            health.Heal(1);
            onPlayerRecharge?.Invoke();
        }
    }
    void RemoveAllLights(GameObject targetObject)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
