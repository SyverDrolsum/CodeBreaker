using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Health health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           health.TakeDamage(1);
        }
    }
}
