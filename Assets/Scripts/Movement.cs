using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    spritechange Spritesc;

    private Animator _animator;
    private bool hasKey = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        
        float newhorizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(newhorizontalInput * moveSpeed, rb.velocity.y);
        _animator.SetFloat("Speed",Mathf.Abs(newhorizontalInput));

        // Horizontal movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
        }

        // Flip character sprite based on movement direction
        if (horizontalInput < 0) // Moving left
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (horizontalInput > 0) // Moving right
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="button")
        {
            Spritesc = collision.gameObject.GetComponent<spritechange>();
            Spritesc.Basildi();
        }
    }
    public bool HasKey()
    {
        return hasKey;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
        }
    }
   

}
