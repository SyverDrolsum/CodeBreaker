using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public int maxHealth = 3;
    public int currentHealth;
    private bool isInvincible = false;

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

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Heal(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

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
        if (currentHealth > 0)
        {
            StartCoroutine(Iframes()); 
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

    private IEnumerator Iframes()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1);
        isInvincible = false;
    }
}
