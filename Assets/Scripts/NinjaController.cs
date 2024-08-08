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
    public float move;
    [SerializeField] Animator anim;
    bool isCrouching;
    public float movey;
    bool isHoldingWeapon = false;
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
        
      

       
    }


    void Move()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        if (rb.velocity.x >0) 
        {
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("Run", true); 
        }
        else if (rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        
        if (isTouchingWall && move != 0 && !isGrounded)
        {
            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        }

    }
    void Jump()
    {
        movey = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.W) && isCrouching == false &&(isTouchingWall == true || isGrounded == true ))
        {
            anim.SetBool("IsPunching", false);
            anim.SetBool("IsJumping", true);
            isGrounded = false;
            isWallSliding = false;
            rb.velocity = new Vector2(rb.velocity.x, movey * jumpForce);
            
        }
    }

    void Crouch()
    {
        isCrouching = Input.GetKey(KeyCode.S);
        
        if (isCrouching) {
            anim.SetBool("IsPunching", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsCrouching", isCrouching);
            rb.velocity = new Vector2(0, -10f);
        }
        else { anim.SetBool("IsCrouching", false); }
    }

    void WallSlide()
    {
        /* if (isWallSliding)
         {
             rb.velocity = new Vector2(rb.velocity.x, -moveSpeed / 2);
         }*/
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

        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(collision.gameObject);
            isHoldingWeapon = true;
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
