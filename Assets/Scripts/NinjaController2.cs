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
    public float move;
    [SerializeField] Animator anim;
    bool isCrouching;
    public float movey;
    public bool isHoldingWeapon = false;
    public bool derecha = true;
    public BoxCollider2D agachar;

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
        CheckHoldingWeapon();
    }

    void Move()
    {
        move = Input.GetAxisRaw("Horizontal2");
        if (move > 0)
        {
            derecha = true;
            GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Run", true);
        }
        else if (move < 0)
        {
            derecha = false;
            GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (isTouchingWall && Input.GetKey(KeyCode.RightArrow) && transform.rotation.y == 0)
        {
            moveSpeed = 0;
        }
        else if (isTouchingWall && Input.GetKey(KeyCode.LeftArrow) && transform.rotation.y == 180)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 5;
        }
    }

    void Jump()
    {
        movey = Input.GetAxisRaw("Vertical2");
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isCrouching && (isTouchingWall || isGrounded))
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
        isCrouching = Input.GetKey(KeyCode.DownArrow);
        if (isCrouching)
        {
            anim.SetBool("IsPunching", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsCrouching", isCrouching);
            rb.velocity = new Vector2(0, -10f);
            agachar.enabled = false;
        }
        else
        {
            anim.SetBool("IsCrouching", false);
            agachar.enabled = true;
        }
    }

    void WallSlide()
    {
        // Uncomment and adjust if you want wall sliding behavior
        // if (isWallSliding)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, -moveSpeed / 2);
        // }
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
            isGrounded = false;
            isTouchingWall = true;
        }

        if (collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(collision.gameObject);
            isHoldingWeapon = true;
            anim.SetBool("IsHoldingManguera", true);
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

    void CheckHoldingWeapon()
    {
        if (isHoldingWeapon)
        {
            anim.SetBool("IsPunching", false);
        }
    }
}
