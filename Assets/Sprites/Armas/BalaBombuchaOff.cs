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

    void Start()
    {
        // Opcional: Puedes inicializar las referencias aqu� si el m�todo Start no es necesario.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reproduce el sonido de explosi�n
        AudioManager.instance.PlaySound(splashSound);

        // Marca el impacto directo si el collider es un jugador
        if (collision.gameObject.CompareTag("player1") || collision.gameObject.CompareTag("player2"))
        {
            isDirectHit = true;
        }

        // Detecta todos los colliders dentro del radio de explosi�n
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
                        // Aplica el efecto de Blink basado en si fue un golpe directo o en �rea
                        if (isDirectHit)
                        {
                            // Da�o directo: llama a Blink 4 veces
                            ninjaBlink.Blink();
                            ninjaBlink.Blink();
                            ninjaBlink.Blink();
                            ninjaBlink.Blink();
                        }
                        else if (!isDirectHit && isWithinExplosionRange)
                        {
                            // Da�o en �rea: llama a Blink 2 veces
                            ninjaBlink.Blink();
                            ninjaBlink.Blink();
                        }
                    }
                }
                else if (hitCollider.CompareTag("player2"))
                {
                    playerBlink2Off ninja2Blink = hitCollider.GetComponent<playerBlink2Off>();
                    if (ninja2Blink != null)
                    {
                        // Aplica el efecto de Blink basado en si fue un golpe directo o en �rea
                        if (isDirectHit)
                        {
                            // Da�o directo: llama a Blink 4 veces
                            ninja2Blink.Blink();
                            ninja2Blink.Blink();
                            ninja2Blink.Blink();
                            ninja2Blink.Blink();
                        }
                        else if (!isDirectHit && isWithinExplosionRange)
                        {
                            // Da�o en �rea: llama a Blink 2 veces
                            ninja2Blink.Blink();
                            ninja2Blink.Blink();
                        }
                    }
                }
            }
        }

        // Destruye la bala despu�s de la explosi�n
        Destroy(gameObject);
    }
}
