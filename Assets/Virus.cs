using UnityEngine;

public class Virus : MonoBehaviour
{
    public Rigidbody2D virusBody;
    public bool playerDetected = true;
    public float moveSpeed;
    private float timer = 10;
    private float cycle = 0;
    private float cycle2 = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected == true)
        {
            if (cycle < timer)
            {
                VirusMoveRight();
                cycle += Time.deltaTime;
            }
            if (cycle > timer && virusBody.linearVelocityX > 0)
            {
                cycle2 = 0;
            }

            if (cycle2 < timer)
            {
                VirusMoveLeft();
                cycle2 += Time.deltaTime;
            }
            if (cycle2 > timer && virusBody.linearVelocityX < 0)
            {
                cycle = 0;
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
}
