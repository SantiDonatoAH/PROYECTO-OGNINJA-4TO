using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpienteOff : MonoBehaviourPunCallbacks
{

    public GameObject ninja1;
    public GameObject ninja2;

    private PlayerBlinkOff ninja1Blink;
    private playerBlink2Off ninja2Blink;

    private NinjaController ninjaController;
    private NinjaController2 ninjaController2;

    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public ScreenController pausemanager;

    private bool canFire = true;
    private bool canFire2 = true;

    public float cooldownTime = .75f;
    public float cooldownTime2 = .75f;

    public float knockbackForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        ninja1 = GameObject.FindWithTag("player1");
        ninja2 = GameObject.FindWithTag("player2");


        ninja1Blink = ninja1.GetComponent<PlayerBlinkOff>();
        ninja2Blink = ninja2.GetComponent<playerBlink2Off>();

        ninjaController = ninja1.GetComponent<NinjaController>();
        ninjaController2 = ninja2.GetComponent<NinjaController2>();

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();


    }

    public void cd1(float cd)
    {
        cooldownTime = cd;
    }
    public void cd2(float cd)
    {
        cooldownTime2 = cd;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && anim.GetBool("IsHoldingSerpiente") == true && canFire)
        {
            canFire = false;
            anim.SetBool("IsAttacking", true);
            if (IsInRange(ninja1, ninja2))
            {
                ApplyKnockback(ninja2Blink.gameObject);
                ninja2Blink.Blink();
                ninja2Blink.Blink();
                ninja2Blink.Blink();
                ninja2Blink.Blink();
                
                StartCoroutine(CooldownRoutineH());
            }
            else
            {
                StartCoroutine(CooldownRoutine());
            }
        }
        if (Input.GetKeyDown(KeyCode.L) && anim2.GetBool("IsHoldingSerpiente2") == true && canFire2)
        {
            canFire2 = false; // Inicia el cooldown para el segundo jugador
            anim2.SetBool("IsAttacking", true);
            if (IsInRange(ninja2, ninja1))
            {
                ApplyKnockback(ninja1Blink.gameObject);
                ninja1Blink.Blink();
                ninja1Blink.Blink();
                ninja1Blink.Blink();
                ninja1Blink.Blink();
                
                StartCoroutine(CooldownRoutine2H());
            }
            else
            {
                StartCoroutine(CooldownRoutine2());
            }
        }
    }

    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 2.5f;
    }

    void endAttack1()
    {
    }
    void endAttack2()
    {
    }

    IEnumerator CooldownRoutineH()
    {

        yield return new WaitForSeconds(cooldownTime / 2);
        anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(cooldownTime / 2);

        ninja2Blink.Blink();
        ninja2Blink.Blink();
        yield return new WaitForSeconds(cooldownTime);
        ninja2Blink.Blink();
        ninja2Blink.Blink();
        canFire = true;
    }

    IEnumerator CooldownRoutine2H()
    {

        yield return new WaitForSeconds(cooldownTime2 / 2);
        anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(cooldownTime2 / 2);

        ninja1Blink.Blink();
        ninja1Blink.Blink();
        yield return new WaitForSeconds(cooldownTime2);
        ninja1Blink.Blink();
        ninja1Blink.Blink();
        canFire2 = true;
    }

    IEnumerator CooldownRoutine()
    {

        yield return new WaitForSeconds(cooldownTime / 2);
        anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(cooldownTime / 2);

        canFire = true;
    }

    IEnumerator CooldownRoutine2()
    {

        yield return new WaitForSeconds(cooldownTime2 / 2);
        anim.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(cooldownTime2/ 2);

        canFire2 = true;
    }

    void ApplyKnockback(GameObject player)
    {
        // Calcula la dirección de knockback como la dirección opuesta a la bala
        Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;

        // Accede al Rigidbody2D del jugador y aplica la fuerza de retroceso
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
