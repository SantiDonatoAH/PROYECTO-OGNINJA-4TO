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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        
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
        if (Input.GetKey(KeyCode.DownArrow))

        {
            //añadir el cambio de sprite
            //por ahora solo detecta la tecla
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            // Si colisiona con una pared, anula la velocidad horizontal
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