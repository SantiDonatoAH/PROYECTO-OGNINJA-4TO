using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManagerOff : MonoBehaviour
{
    public GameObject ninja1;
    public GameObject ninja2;

    public PlayerBlinkOff ninja1Blink;
    public playerBlink2Off ninja2Blink;

    private ninjaControllerOff ninjaController;
    private ninjaController2Off ninjaController2;

    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public ScreenController pausemanager;

    public KnockbackManager KnockbackManager;


    public float cooldownTime = .5f;
    public float cooldownTime2 = .5f;

    private bool canFire = true;
    private bool canFire2 = true;

    public endAttack endAttack;
    public endAttack2 endAttack2;


    void Start()
    {

        ninja1 = GameObject.FindGameObjectWithTag("player1");
        ninja2 = GameObject.FindGameObjectWithTag("player2");

       

        ninjaController = ninja1.GetComponent<ninjaControllerOff>();
        ninjaController2 = ninja2.GetComponent<ninjaController2Off>();

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();

        endAttack = ninja1.GetComponent<endAttack>();
        endAttack2 = ninja2.GetComponent<endAttack2>();

    }

    void Update()
    {
        HandleCombat();
    }

    void HandleCombat()
    {
        if (pausemanager.ispaused == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && ninjaController.isHoldingWeapon == false && canFire)
            {
                anim.SetBool("IsPunching", true);
                if (IsInRange(ninja1, ninja2) &&
                 ((ninja2.transform.position.x < ninja1.transform.position.x && ninja1.transform.rotation.eulerAngles.y > 0) ||
                (ninja2.transform.position.x > ninja1.transform.position.x && ninja1.transform.rotation.eulerAngles.y < 100)))
                {
                    ninja2Blink.Blink();
                    KnockbackManager.Ninja2();
                    StartCoroutine(CooldownRoutine());

                }
                StartCoroutine(endAttack.endAttack1());
            }

            if (Input.GetKeyDown(KeyCode.L) && ninjaController2.isHoldingWeapon == false && canFire2)
            {
                anim2.SetBool("IsPunching", true);
                if (IsInRange(ninja2, ninja1) &&
                     ((ninja1.transform.position.x < ninja2.transform.position.x && ninja2.transform.rotation.eulerAngles.y > 0) ||
                     (ninja1.transform.position.x > ninja2.transform.position.x && ninja2.transform.rotation.eulerAngles.y < 100)))
                {
                    ninja1Blink.Blink();
                    KnockbackManager.Ninja1();
                    StartCoroutine(CooldownRoutine2());
                }
                StartCoroutine(endAttack2.endAttack());

            }
        }
    }



    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 1.5f;
    }




    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        canFire = true; // Habilita el disparo nuevamente después de 1.5 segundos
    }

    IEnumerator CooldownRoutine2()
    {
        yield return new WaitForSeconds(cooldownTime2);
        canFire2 = true; // Habilita el disparo nuevamente después de 1.5 segundos
    }
}
