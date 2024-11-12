using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NinjaController2 : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float move;
    public float movey;

    private Rigidbody2D rb;
    [SerializeField] Animator anim;
    public BoxCollider2D agachar;
    public BoxCollider2D parado;

    public GameObject pared;
    public Transform paredT;

    private bool isGrounded = false;
    private bool isTouchingWall = false;
    bool isCrouching;
    public bool isHoldingWeapon = false;
    public string weaponName;

    public float kita;
    public float kitaJ;
    public float saltoDoble;

    public ParticleSystem footstepParticles2;
    public ParticleSystem jumpParticles2;
    public ParticleSystem landParticles2;
    public ParticleSystem wallSlideParticles2;

    [SerializeField] private AudioClip[] grassStepSound2;
    [SerializeField] private AudioClip[] grassJumpSound2;
    [SerializeField] private AudioClip[] crouchSound2;
    [SerializeField] private AudioClip wallSlideSound2;

    private AudioSource audioSource2;

    public GameObject combatG;
    public CombatManager combat;

    private AudioSource audioSource;

    PhotonView view;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        combatG = GameObject.FindGameObjectWithTag("combat");
        combat = combatG.GetComponent<CombatManager>();

        rb = GetComponent<Rigidbody2D>();

        view = GetComponent<PhotonView>();

        kita = moveSpeed;
        kitaJ = jumpForce;
        saltoDoble = kitaJ * 3;

        audioSource2 = GetComponent<AudioSource>();
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (view.IsMine)
        {
            Move();
            Jump();
            Crouch();
            CheckHoldingWeapon();
            WallSlide();


            if (move != 0 && isGrounded && !isTouchingWall && !isCrouching)
            {
                if (!footstepParticles2.isPlaying)
                    footstepParticles2.Play();
                PlayRandomStepSound2();
            }
            else
            {
                if (footstepParticles2.isPlaying)
                    footstepParticles2.Stop();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                combat.HandleCombat(false);
            }
        }

    }

    [PunRPC]
    public void salto(int saltof)
    {
        jumpForce = saltof;
    }
    [PunRPC]
    public void vel(float velf)
    {
        moveSpeed = velf;
        kita = velf;
    }

    void Move()
    {
        move = Input.GetAxisRaw("Horizontal2");
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

        if ((Input.GetKey(KeyCode.RightArrow) && transform.position.x < paredT.transform.position.x && transform.rotation.y == 0 && isTouchingWall) ||
            (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > paredT.transform.position.x && transform.rotation.y < 100 && isTouchingWall))
        {
            moveSpeed = 0;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 1.5f);
            anim.SetBool("IsWallSliding", true);
            //PlayWallSlideSound2();
        }
        else
        {
            moveSpeed = kita;
            anim.SetBool("IsWallSliding", false);
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

            jumpParticles2.Play();
            PlayRandomJumpSound2();
        }
    }

    void Crouch()
    {
        isCrouching = Input.GetKey(KeyCode.DownArrow);
        if (isCrouching)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PlayRandomCrouchSound2();
            }
            anim.SetBool("IsPunching", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsCrouching", isCrouching);
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
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
        if (anim.GetBool("IsWallSliding"))
        {
            if (!wallSlideParticles2.isPlaying)
            {
                wallSlideParticles2.Play();
            }

            if (!audioSource2.isPlaying)
            {
                audioSource2.PlayOneShot(wallSlideSound2);
            }

            wallSlideParticles2.transform.position = new Vector3(transform.position.x, transform.position.y, wallSlideParticles2.transform.position.z);
        }
        else
        {
            if (wallSlideParticles2.isPlaying)
            {
                wallSlideParticles2.Stop();
            }
        }
    }

    [PunRPC]
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsJumping", false);
            isGrounded = true;

            if (jumpParticles2.isPlaying)
            {
                jumpParticles2.Stop();
            }

            if (!landParticles2.isPlaying)
            {

                landParticles2.Play();
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            anim.SetBool("IsJumping", false);
            isTouchingWall = true;
            pared = collision.gameObject;
            paredT = pared.GetComponent<Transform>();
        }

        if (collision.gameObject.tag == "Weapon" && Input.GetKey(KeyCode.DownArrow))
        {
            string newWeaponName = collision.gameObject.name.Replace("(Clone)", "").Trim();

            if (isHoldingWeapon)
            {
                // Cambiar el arma actual por la nueva
                anim.SetBool("IsHolding" + weaponName + "2", false);
            }

            // Agarrar la nueva arma
            weaponName = newWeaponName;
            collision.gameObject.transform.position = new Vector2(100, 0);
            isHoldingWeapon = true;
            anim.SetBool("IsHolding" + newWeaponName + "2", true);
            anim.SetBool("IsHoldingWeapon2", true);

            var script = collision.gameObject.GetComponent(newWeaponName + "100") as MonoBehaviourPunCallbacks;
            script.photonView.RPC("Mover", RpcTarget.AllBuffered); // Llamada RPC para sincronizar el daño entre todas las sesiones
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

    private void PlayRandomStepSound2()
    {
        if (!audioSource2.isPlaying)
        {
            AudioClip randomStepSound = grassStepSound2[Random.Range(0, grassStepSound2.Length)];
            audioSource2.PlayOneShot(randomStepSound);
        }
    }

    private void PlayRandomJumpSound2()
    {
        AudioClip randomJumpSound = grassJumpSound2[Random.Range(0, grassJumpSound2.Length)];
        audioSource2.PlayOneShot(randomJumpSound);
    }

    private void PlayRandomCrouchSound2()
    {
        AudioClip randomCrouchSound = crouchSound2[Random.Range(0, crouchSound2.Length)];
        audioSource2.PlayOneShot(randomCrouchSound);
    }
}
