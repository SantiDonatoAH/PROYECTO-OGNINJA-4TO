using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BalaBoomerang2 : MonoBehaviourPunCallbacks
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

    public float cooldownTime = 2f;

    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlink>();

        combatManager = GameObject.FindWithTag("combat");
        KnockbackManager = combatManager.GetComponent<KnockbackManager>();


        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();

        StartCoroutine(CooldownRoutine()); // Inic

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

      
         if (collision.gameObject.CompareTag("player1"))
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
        }
    }



    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
    }

}
