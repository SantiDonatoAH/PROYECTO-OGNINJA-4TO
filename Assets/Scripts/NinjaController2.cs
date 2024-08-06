using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isTouchingWall = false;
    private bool isWallSliding = false;
    bool crouch = false;
    bool isCrouching = false;
    [SerializeField] Animator anim;

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
        
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGrounded || isTouchingWall) && isCrouching == false)
        {
            anim.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            isWallSliding = false;
            
        }
    }
    void Crouch()
    {
        isCrouching = Input.GetKey(KeyCode.DownArrow);
        if (isCrouching)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsCrouching", isCrouching);
            rb.velocity = new Vector2(0, -10f);
        }
        else { anim.SetBool("IsCrouching", false); rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y); }
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
        isGrounded = true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsJumping", false);
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            anim.SetBool("IsJumping", false);
            isGrounded = false;
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
