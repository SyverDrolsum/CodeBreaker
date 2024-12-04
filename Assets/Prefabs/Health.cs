using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
   // public Image healthBar;
    public int maxHealth = 3;
    public int currentHealth;
    private Rigidbody2D pushedBody;
    private bool isInvincible = false;
    private float virus_value;
    private float player_value;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip damageSound;


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
//            SoundManager.instance.PlaySound(deathSound);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //Helper functions when testing the health.
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Heal(1);
        }
    }

    //Function for player taking damage and changing state/size of player and running Iframes function
    public void TakeDamage(int damage)
    {
        if (isInvincible) return;


        currentHealth -= damage;
      //  healthBar.fillAmount = currentHealth / 3f;
        if (currentHealth == 2)
        {
      //      SoundManager.instance.PlaySound(damageSound);
            sizeManager.ToMediumState();
            //This was an attempt to make a better way to push the player when it lost life.
            /* 
            virus_value = GameObject.FindGameObjectWithTag("Virus").transform.position.x;
            player_value = GameObject.FindGameObjectWithTag("Player").transform.position.x;
            float direction = Mathf.Sign(virus_value - player_value);
            pushedBody = GameObject.FindGameObjectWithTag("MedPlayer").GetComponent<Rigidbody2D>();
            if (direction > 0)
            {
                pushedBody.AddForce(Vector2.left * 1000, ForceMode2D.Impulse);
            }
            else
            {
                pushedBody.AddForce(Vector2.right * 1000, ForceMode2D.Impulse);
            }*/

        }
        if (currentHealth == 1)
        {
        //    SoundManager.instance.PlaySound(damageSound);
            sizeManager.ToSmallState();
            //This was an attempt to make a better way to push the player when it lost life.
            /*
            virus_value = GameObject.FindGameObjectWithTag("Virus").transform.position.x;
            player_value = GameObject.FindGameObjectWithTag("MedPlayer").transform.position.x;
            float direction = Mathf.Sign(virus_value - player_value);
            pushedBody = GameObject.FindGameObjectWithTag("SmallPlayer").GetComponent<Rigidbody2D>();
            if (direction > 0)
            {
                pushedBody.AddForce(Vector2.left * 1000, ForceMode2D.Impulse);
            }
            else
            {
                pushedBody.AddForce(Vector2.right * 1000, ForceMode2D.Impulse);
            }*/
        }
        if (currentHealth > 0)
        {
            StartCoroutine(Iframes()); 
        }
    }

    //Function for healing player and changing state/size of player

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
     //   healthBar.fillAmount = currentHealth / 3f;

        if (currentHealth == 2)
        {
            sizeManager.ToMediumState();
        }
        if (currentHealth == 3)
        {
            sizeManager.ToNormalState();
        }
    }

    //Adding Iframes to player when daking damage
    private IEnumerator Iframes()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1);
        isInvincible = false;
    }
}
