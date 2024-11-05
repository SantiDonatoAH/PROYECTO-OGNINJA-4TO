using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaOff : MonoBehaviour
{
    private playerBlink2Off ninja2Blink;
    private PlayerBlinkOff ninjaBlink;
    [SerializeField] private AudioClip ouchSound;

    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public GameObject ninja1;
    public GameObject ninja2;
    public GameObject combatManager;
    public float knockbackForce = 10f;

    void Start()
    {

        ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2Off>();

        ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlinkOff>();

        combatManager = GameObject.FindWithTag("combat");
       


        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("player2"))
        {
            Destroy(gameObject);
            ApplyKnockback(collision, ninja2Blink.gameObject);
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            
            StartCoroutine(ResetBlink(anim2));
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("player1"))
        {
            Destroy(gameObject);
            ApplyKnockback(collision, ninjaBlink.gameObject);
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            
            StartCoroutine(ResetBlink(anim2));
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("Weapon"))
        {

        }
        else
        {
            
            Destroy(gameObject);
        }
    }

    IEnumerator ResetBlink(Animator animator)
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsBlinking", false);
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
}
