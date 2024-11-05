using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaRocaOff : MonoBehaviour
{
    private playerBlink2Off ninja2Blink;
    private PlayerBlinkOff ninjaBlink;


    private bool isDirectHit = false;

    public float knockbackForce = 10f;

    void Start()
    {
        // Opcional: Puedes inicializar las referencias aquí si el método Start no es necesario.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reproduce el sonido de explosión

        // Marca el impacto directo si el collider es un jugador
        if (collision.gameObject.CompareTag("player1"))
        {
            ninjaBlink = collision.gameObject.GetComponent<PlayerBlinkOff>();
            ApplyKnockback(collision, ninjaBlink.gameObject);
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
        }

        if (collision.gameObject.CompareTag("player2"))
        {
            ninja2Blink = collision.gameObject.GetComponent<playerBlink2Off>();

            ApplyKnockback(collision, ninja2Blink.gameObject);
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
        }

        // Destruye la bala después de la explosión
        Destroy(gameObject);
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
