using Photon.Pun;
using UnityEngine;

public class ninjaControllerOff : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7.5f;
    public float move;
    public float movey;

    public Rigidbody2D rb;
    [SerializeField] Animator anim;
    public BoxCollider2D agachar;
    public BoxCollider2D parado;

    public GameObject pared;
    public Transform paredT;

    private bool isGrounded = false;
    public bool isTouchingWall = false;
    bool isCrouching;
    public bool isHoldingWeapon = false;
    public string weaponName;

    public float kita;
    public float kitaJ;
    public float saltoDoble;

    // Variable para el Particle System de los pasos
    public ParticleSystem footstepParticles;
    public ParticleSystem jumpParticles;
    public ParticleSystem landParticles;
    public ParticleSystem wallSlideParticles;

    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();

        kita = moveSpeed;
        kitaJ = jumpForce;
        saltoDoble = kitaJ * 2;
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

        if (isTouchingWall && Input.GetKey(KeyCode.A))
        {
            jumpForce = saltoDoble;
        }
        else
        {
            jumpForce = kitaJ;
        }

        // Control de las part�culas al caminar
        if (move != 0 && isGrounded && !isTouchingWall && !isCrouching)
        {
            if (!footstepParticles.isPlaying)
                footstepParticles.Play();
        }
        else
        {
            if (footstepParticles.isPlaying)
                footstepParticles.Stop();
        }
    }

    void Move()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        if (rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Run", true);
        }
        else if (rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if
        ((Input.GetKey(KeyCode.D) && transform.position.x < paredT.transform.position.x && transform.rotation.y == 0 && isTouchingWall) ||
                (Input.GetKey(KeyCode.A) && transform.position.x > paredT.transform.position.x && transform.rotation.y < 100 && isTouchingWall))
        {
            moveSpeed = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 1.5f);
            anim.SetBool("IsWallSliding", true);
        }
        else
        {
            moveSpeed = kita;
            anim.SetBool("IsWallSliding", false);
        }
    }

    void Jump()
    {
        movey = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.W) && !isCrouching && (isTouchingWall || isGrounded) && !jumpParticles.isPlaying)
        {
            anim.SetBool("IsPunching", false);
            anim.SetBool("IsJumping", true);
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, movey * jumpForce);
            jumpParticles.Play();
        }
        else if (Input.GetKeyDown(KeyCode.W) && !isCrouching && (isTouchingWall || isGrounded) && jumpParticles.isPlaying)
        {
            anim.SetBool("IsPunching", false);
            anim.SetBool("IsJumping", true);
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, movey * jumpForce);
            jumpParticles.Stop();
        }
    }



    void Crouch()
    {
        isCrouching = Input.GetKey(KeyCode.S);
        if (isCrouching)
        {
            anim.SetBool("IsPunching", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsCrouching", isCrouching);
            rb.velocity = new Vector2(0, -10f);
            agachar.enabled = true;
            parado.enabled = false;
        }
        else
        {
            anim.SetBool("IsCrouching", false);
            agachar.enabled = false;
            parado.enabled = true;
        }
    }

    void WallSlide()
    {
        // Si la animaci�n de "IsWallSliding" est� activa, activamos las part�culas
        if (anim.GetBool("IsWallSliding"))
        {
            if (!wallSlideParticles.isPlaying)
            {
                wallSlideParticles.Play();
            }

            // Actualizamos la posici�n de las part�culas para que sigan al jugador
            wallSlideParticles.transform.position = new Vector3(transform.position.x, transform.position.y, wallSlideParticles.transform.position.z);
        }
        else
        {
            // Si la animaci�n no est� activa, detenemos las part�culas
            if (wallSlideParticles.isPlaying)
            {
                wallSlideParticles.Stop();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsJumping", false);
            isGrounded = true;
            jumpParticles.Play();
        }


        if (collision.gameObject.CompareTag("Wall"))
        {
            anim.SetBool("IsJumping", false);
            isTouchingWall = true;
            pared = collision.gameObject;
            paredT = pared.GetComponent<Transform>();
        }

        if (collision.gameObject.tag == "Weapon" && Input.GetKey(KeyCode.S))
        {
            string newWeaponName = collision.gameObject.name.Replace("(Clone)", "").Trim();

            if (isHoldingWeapon)
            {
                // Cambiar el arma actual por la nueva
                anim.SetBool("IsHolding" + weaponName, false);
            }

            // Agarrar la nueva arma
            weaponName = newWeaponName;
            collision.gameObject.transform.position = new Vector2(100, 0);  // Mover el arma agarrada fuera de la pantalla
            isHoldingWeapon = true;
            anim.SetBool("IsHolding" + weaponName, true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isTouchingWall = false;
            anim.SetBool("IsWallSliding", false);
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