using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public Rigidbody2D virusBody;
    public BoxCollider2D detectionRange;
    public bool playerDetected = true;
    public float moveSpeed;
    private float timer = 10;
    private float cycle = 0;
    private float cycle2 = 10;
    private float player_x_value;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected == true)
        {
            if (cycle < timer)
            {
                anim.SetBool("isMoving", true);
                VirusMoveRight();
                cycle += Time.deltaTime;
            }
            if (cycle > timer && virusBody.linearVelocityX > 0)
            {
                cycle2 = 0;
            }

            if (cycle2 < timer)
            {
                anim.SetBool("isMoving", true);
                VirusMoveLeft();
                cycle2 += Time.deltaTime;
            }
            if (cycle2 > timer && virusBody.linearVelocityX < 0)
            {
                cycle = 0;
            }
        }
        else
        { 
            float virus_x_value = virusBody.transform.position.x;
            if (virus_x_value < player_x_value)
            {
                VirusMoveRight();
            }
            else
            {
                VirusMoveLeft();
            }
        }
    }
    void VirusMoveRight()
    {
        virusBody.linearVelocity = Vector2.right * moveSpeed;
    }

    void VirusMoveLeft()
    {
        virusBody.linearVelocity = Vector2.left * moveSpeed;
    }

    void VirusMoveStop()
    {
        virusBody.linearVelocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_x_value = collision.transform.position.x;
        } 
    }

}
