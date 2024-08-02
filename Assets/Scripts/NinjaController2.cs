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

        if (Input.GetKeyDown(KeyCode.L))
        {
            damageP1.Blink();
        }
    }

    void Move()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
            rb.velocity = new Vector2(moveSpeed * moveInput, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
            rb.velocity = new Vector2(moveSpeed * moveInput, rb.velocity.y);
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow) && isTouchingWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void Crouch()
    {
        bool isCrouching = Input.GetKey(KeyCode.DownArrow);
        anim.SetBool("IsCrouching", isCrouching);
        if(isCrouching == true) { rb.velocity = new Vector2(0, -10f); }
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