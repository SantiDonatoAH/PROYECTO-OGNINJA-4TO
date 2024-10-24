﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bala : MonoBehaviourPunCallbacks
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
            PhotonNetwork.Destroy(gameObject);

            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            KnockbackManager.Ninja2();
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("player1"))
        {
            PhotonNetwork.Destroy(gameObject);

            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            KnockbackManager.Ninja1();
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("Weapon"))
        {

        }
        else
        {
            Debug.Log("jsd");
            PhotonNetwork.Destroy(gameObject);
        }        }

   
}
