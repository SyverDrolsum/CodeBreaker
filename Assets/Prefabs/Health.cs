using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public int maxHealth = 3;
    public int currentHealth;

    public SizeManager sizeManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Heal(1);
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 3f;
        if (currentHealth == 2)
        {
            sizeManager.ToMediumState();
        }
        if (currentHealth == 1)
        {
            sizeManager.ToSmallState();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.fillAmount = currentHealth / 3f;

        if (currentHealth == 2)
        {
            sizeManager.ToMediumState();
        }
        if (currentHealth == 3)
        {
            sizeManager.ToNormalState();
        }
    }
}
