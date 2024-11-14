using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BalaBoomerang2Off : MonoBehaviourPunCallbacks
{
    private playerBlink2 ninja2Blink;
    private PlayerBlinkOff ninjaBlink;
    [SerializeField] private AudioClip ouchSound;

    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public GameObject ninja1;
    public GameObject ninja2;
    public GameObject combatManager;

    public float knockbackForce = 10f;

    public float cooldownTime = 2f;

    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlinkOff>();

        combatManager = GameObject.FindWithTag("combat");
        


        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();

        StartCoroutine(CooldownRoutine()); // Inic

    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("player1"))
        {
           Destroy(gameObject);

            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ApplyKnockback(collision, ninjaBlink.gameObject);
            AudioManager.instance.PlaySound(ouchSound);
            Destroy(gameObject);

        }

        else if (collision.gameObject.CompareTag("Weapon"))
        {

        }
        else
        {
            Debug.Log("jsd");
            Destroy(gameObject);
        }
    }

    void ApplyKnockback(Collision2D collision, GameObject player)
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

    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
    }

}
