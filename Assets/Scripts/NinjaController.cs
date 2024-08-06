using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isTouchingWall = false;
    private bool isWallSliding = false;
    public PlayerBlink damageP1;
    public GameObject puño;
    bool crouch = false;
    [SerializeField] Animator anim;
    bool isCrouching;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        Crouch();
        WallSlide();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            damageP1.Blink();
        }

        
        if (isTouchingWall && !isGrounded && rb.velocity.y <= 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed / 2);
        }
        else
        {
            isWallSliding = false;
        }

       
    }
    

    void Move()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

       
        if (isTouchingWall && moveInput != 0 && !isGrounded)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || isTouchingWall || isWallSliding) && isCrouching == false)
        {
            anim.SetBool("IsJumping", true);
            isGrounded = false;
            isWallSliding = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }
    }

    void Crouch()
    {
        isCrouching = Input.GetKey(KeyCode.S);
        
        if (isCrouching) {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsCrouching", isCrouching);
            rb.velocity = new Vector2(0, -10f);
        }
        else { anim.SetBool("IsCrouching", false); }
    }

    void WallSlide()
    {
        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed / 2);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsJumping", false);
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            anim.SetBool("IsJumping", false);
            isTouchingWall = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
            isWallSliding = false;
        }
    }
}
