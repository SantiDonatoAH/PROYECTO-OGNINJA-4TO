using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isTouchingWall = false;
    public PlayerBlink damageP1;
    public GameObject puño;
    bool crouch = false;
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            damageP1.Blink();
        }
       
        if (isTouchingWall == true)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);       
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
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.W) && isTouchingWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void Crouch()
    {
        bool isCrouching = Input.GetKey(KeyCode.S);
        anim.SetBool("IsCrouching", isCrouching);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            
            rb.velocity = new Vector2(0, rb.velocity.y);
            isTouchingWall = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
        }
    }
}