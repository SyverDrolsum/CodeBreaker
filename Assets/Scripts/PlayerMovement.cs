using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class JumpController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] int jumpPower;

    public float moveSpeed = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    private float horizontal;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flip();

        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.02f, 0.16f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
    }

    private void Flip()
    {
        if ((horizontal > 0f && !isFacingRight) || (horizontal < 0f && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
