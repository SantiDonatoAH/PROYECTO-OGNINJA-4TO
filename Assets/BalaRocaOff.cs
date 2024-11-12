using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaRocaOff : MonoBehaviour
{
    public string shooterTag; // Nuevo: Identifica quién disparó la bala

    private playerBlink2Off ninja2Blink;
    private PlayerBlinkOff ninjaBlink;

    private bool isDirectHit = false;

    public float knockbackForce = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la bala colisiona con el jugador que la disparó, no hace nada
        if (collision.gameObject.CompareTag(shooterTag))
        {
            return; // Ignora la colisión con el propio jugador
        }

        // Lógica de colisión y daño a otros jugadores
        if (collision.gameObject.CompareTag("player1"))
        {
            ninjaBlink = collision.gameObject.GetComponent<PlayerBlinkOff>();
            ApplyKnockback(collision, ninjaBlink.gameObject);
            ninjaBlink.Blink();
        }

        if (collision.gameObject.CompareTag("player2"))
        {
            ninja2Blink = collision.gameObject.GetComponent<playerBlink2Off>();
            ApplyKnockback(collision, ninja2Blink.gameObject);
            ninja2Blink.Blink();
        }

        // Destruye la bala después de la colisión
        Destroy(gameObject);
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