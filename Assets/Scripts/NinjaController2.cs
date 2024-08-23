using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float move;
    public float movey;

    private Rigidbody2D rb;
    [SerializeField] Animator anim;
    public BoxCollider2D parar;
    public BoxCollider2D agachar;

    private bool isGrounded = false;
    private bool isTouchingWall = false;
    bool isCrouching;
    public bool isHoldingWeapon = false;
    public bool derecha = true;
    public string weaponName;

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
        CheckHoldingWeapon();
        WallSlide();
    }

    void Move()
    {
        move = Input.GetAxisRaw("Horizontal2");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        if (rb.velocity.x > 0)
        {
            derecha = true;
            GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0); // Rotación normal
            anim.SetBool("Run", true);
        }
        else if (rb.velocity.x < 0)
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

        if (isTouchingWall == true && Input.GetKey(KeyCode.RightArrow) && transform.rotation.y == 0)
        {
            moveSpeed = 0;
        }
        else if (isTouchingWall == true && Input.GetKey(KeyCode.LeftArrow) && transform.rotation.y != 0)
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
            agachar.enabled = true;
            parar.enabled = false;
        }
        else
        {
            anim.SetBool("IsCrouching", false);
            agachar.enabled = false;
            parar.enabled = true;
        }
    }

    void WallSlide()
    {
        if (isTouchingWall == true)
        {
            anim.SetBool("IsWallSliding", true);
        }

        else
        {
            anim.SetBool("IsWallSliding", false);
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

        if (collision.gameObject.CompareTag("Weapon"))
        {
            string newWeaponName = collision.gameObject.name.Replace("(Clone)", "2").Trim();

            if (isHoldingWeapon)
            {
                // Cambiar el arma actual por la nueva
                anim.SetBool("IsHolding" + weaponName, false);
            }

            // Agarrar la nueva arma
            weaponName = newWeaponName;
            collision.gameObject.transform.position = new Vector2(35, 0);  // Mover el arma agarrada fuera de la pantalla
            isHoldingWeapon = true;
            anim.SetBool("IsHolding" + weaponName, true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
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
