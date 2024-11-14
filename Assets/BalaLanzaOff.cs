using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaLanzaOff : MonoBehaviour
{
    public string shooterTag; // Nuevo: Identifica quién disparó la bala

    private playerBlink2Off ninja2Blink;
    private PlayerBlinkOff ninjaBlink;

    private bool isDirectHit = false;

    public float knockbackForce = 10f;

    public Rigidbody2D rb;
    public float i = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la bala colisiona con el jugador que la disparó, no hace nada


        // Lógica de colisión y daño a otros jugadores
        if (collision.gameObject.CompareTag("player1"))
        {
            if (name == "LanzaBO2(Clone)")
            {
                ninjaBlink = collision.gameObject.GetComponent<PlayerBlinkOff>();
                ApplyKnockback(collision, ninjaBlink.gameObject);

                float kita = rb.velocity.x;
                for (  ;i <kita; i++)
                {
                    ninjaBlink.Blink();
                }
            }
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("player2"))
        {
            if (name == "LanzaBO(Clone)")
            {
                ninja2Blink = collision.gameObject.GetComponent<playerBlink2Off>();
                ApplyKnockback(collision, ninja2Blink.gameObject);
                float kita = rb.velocity.magnitude;
                for (int i = 0; i < kita; i++)
                {
                    Debug.Log(i);
                    ninja2Blink.Blink();
                }
            }
            Destroy(gameObject);

        }
        Destroy(gameObject);

        // Destruye la bala después de la colisión
    }

    void ApplyKnockback(Collision2D collision, GameObject player)
    {
        Vector2 knockbackDirection = (player.transform.position - transform.position).normalized;
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}