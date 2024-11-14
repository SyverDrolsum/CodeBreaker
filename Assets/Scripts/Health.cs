using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public int maxHealth = 3;
    public int currentHealth;
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
        /*
        if (Input.GetKeyUp(KeyCode.W))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Heal(1);
        }
        */
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 3f;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.fillAmount = currentHealth / 3f;
    }
}
