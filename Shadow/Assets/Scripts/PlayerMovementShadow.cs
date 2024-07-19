using UnityEngine;

public class PlayerMovementShadow : MonoBehaviour
{
    private float horizontal;
    private float speed = 7f;
    private float jumpingPower = -6f; 
    private bool isFacingRight = true;
    private Animator animator;
    public PlayerMovement playerMovement;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(playerMovement.PotEffect)
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y < 0f) 
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
        
        Flip();

        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void UpdateAnimation()
    {
        // Define a velocidade absoluta no eixo X
        float absoluteVelocityX = Mathf.Abs(rb.velocity.x);

        // Verifica se o jogador está se movendo no eixo X (andando)
        if (absoluteVelocityX > 0.1f && IsGrounded())
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
