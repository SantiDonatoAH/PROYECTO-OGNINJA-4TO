﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private playerBlink2 ninja2Blink;
    private PlayerBlink ninjaBlink;
    [SerializeField] private AudioClip ouchSound;

    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public GameObject ninja1;
    public GameObject ninja2;
    public GameObject combatManager;

    public KnockbackManager KnockbackManager;
    void Start()
    {

         ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

         ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlink>();

        combatManager = GameObject.FindWithTag("combat");
        KnockbackManager = combatManager.GetComponent<KnockbackManager>();


        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("player2"))
        {
            Destroy(gameObject);

            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            KnockbackManager.Ninja2();
            StartCoroutine(ResetBlink(anim2));
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("player1"))
        {
            Destroy(gameObject);

            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            KnockbackManager.Ninja1();
            StartCoroutine(ResetBlink(anim2));
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("Weapon"))
        {

        }
        else {
            Debug.Log("jsd");
            Destroy(gameObject); }
    }

    IEnumerator ResetBlink(Animator animator)
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsBlinking", false);
    }
}