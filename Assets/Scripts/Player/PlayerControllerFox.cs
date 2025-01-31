using UnityEngine;

public class PlayerControllerFox : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D playerRB;
    private bool isGrounded;
    private bool isFalling;
    private bool canJump = true;

    private Animator animator;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        CheckGrounded();
        HandleJump();
        UpdateFallingState();
    }

    void HandleMovement()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }
        playerRB.linearVelocity = new Vector2(moveInput * moveSpeed, playerRB.linearVelocity.y);

        if (moveInput < 0)
            animator.SetFloat("Direction", -1.0f);
        else if (moveInput > 0)
            animator.SetFloat("Direction", 1.0f);

        animator.SetFloat("Speed", Mathf.Abs(playerRB.linearVelocity.x) / moveSpeed);
        animator.SetBool("IsFalling", (playerRB.linearVelocity.y < -0.1f));
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpForce);
            canJump = false;
            animator.SetBool("IsJumping", true);
        }
    }

    void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1.0f, 0.5f), 0f, Vector2.down, 0.5f, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
        isGrounded = hit.collider != null;

        if (isGrounded)
        {
            canJump = true;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }
    }

    void UpdateFallingState()
    {
        isFalling = playerRB.linearVelocity.y < 0 && !isGrounded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            GameManager.Instance.AddScore(1);
            Destroy(collision.gameObject);
        }
    }
}
