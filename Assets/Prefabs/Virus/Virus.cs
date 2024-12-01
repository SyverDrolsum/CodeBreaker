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
        //Virus moves a certain amount to the right before turning around as long as a gameobject tagged
        // Player doesn't enter it's detection trigger
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
    //Functions to move right, left and stop.
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
    //Functions that trigger to follow the object tagged Player when it enters, read it's x-value while in 
    //the trigger and stopping when one has left.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("MedPlayer")||collision.gameObject.CompareTag("SmallPlayer"))
        {
            playerDetected = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("MedPlayer")||collision.gameObject.CompareTag("SmallPlayer"))
        {
            playerDetected = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("MedPlayer")||collision.gameObject.CompareTag("SmallPlayer"))
        {
            player_x_value = collision.transform.position.x;
        } 
    }

}
