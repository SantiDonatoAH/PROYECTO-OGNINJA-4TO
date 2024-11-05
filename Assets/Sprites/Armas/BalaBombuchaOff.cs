using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBombuchaOff : MonoBehaviour
{
    private playerBlink2Off ninja2Blink;
    private PlayerBlinkOff ninjaBlink;

    [SerializeField] private AudioClip splashSound;
    public float radioExplosion = 2f;
    private bool isDirectHit = false;
    public float knockbackForce = 10f;

    void Start()
    {
        // Opcional: Puedes inicializar las referencias aquí si el método Start no es necesario.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reproduce el sonido de explosión
        AudioManager.instance.PlaySound(splashSound);

        // Marca el impacto directo si el collider es un jugador
        if (collision.gameObject.CompareTag("player1") || collision.gameObject.CompareTag("player2"))
        {
            isDirectHit = true;
        }

        // Detecta todos los colliders dentro del radio de explosión
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radioExplosion);
        foreach (var hitCollider in hitColliders)
        {
            // Verifica si el collider pertenece a un jugador
            if (hitCollider.CompareTag("player1") || hitCollider.CompareTag("player2"))
            {
                float distance = Vector2.Distance(transform.position, hitCollider.transform.position);
                bool isWithinExplosionRange = distance <= radioExplosion;

                if (hitCollider.CompareTag("player1"))
                {
                    PlayerBlinkOff ninjaBlink = hitCollider.GetComponent<PlayerBlinkOff>();
                    if (ninjaBlink != null)
                    {
                        // Aplica el efecto de Blink basado en si fue un golpe directo o en área
                        if (isDirectHit)
                        {
                            // Daño directo: llama a Blink 4 veces
                            ninjaBlink.Blink();
                            ninjaBlink.Blink();
                            ninjaBlink.Blink();
                            ninjaBlink.Blink();
                            ApplyKnockback(collision, ninjaBlink.gameObject);
                        }
                        else if (!isDirectHit && isWithinExplosionRange)
                        {
                            // Daño en área: llama a Blink 2 veces
                            ninjaBlink.Blink();
                            ninjaBlink.Blink();
                            ApplyKnockback(collision, ninjaBlink.gameObject);
                        }
                    }
                }
                else if (hitCollider.CompareTag("player2"))
                {
                    playerBlink2Off ninja2Blink = hitCollider.GetComponent<playerBlink2Off>();
                    if (ninja2Blink != null)
                    {
                        // Aplica el efecto de Blink basado en si fue un golpe directo o en área
                        if (isDirectHit)
                        {
                            // Daño directo: llama a Blink 4 veces
                            ninja2Blink.Blink();
                            ninja2Blink.Blink();
                            ninja2Blink.Blink();
                            ninja2Blink.Blink();
                            ApplyKnockback(collision, ninja2Blink.gameObject);
                        }
                        else if (!isDirectHit && isWithinExplosionRange)
                        {
                            // Daño en área: llama a Blink 2 veces
                            ninja2Blink.Blink();
                            ninja2Blink.Blink();
                            ApplyKnockback(collision, ninja2Blink.gameObject);
                        }
                    }
                }
            }
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
