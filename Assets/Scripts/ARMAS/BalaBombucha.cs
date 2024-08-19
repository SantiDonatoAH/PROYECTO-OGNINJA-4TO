using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBombucha : MonoBehaviour
{
    private playerBlink2 ninja2Blink;
    private PlayerBlink ninjaBlink;

    [SerializeField] private AudioClip splashSound;
    public float radioExplosion = 2f;
    private bool isDirectHit = false;

    void Start()
    {
        // Opcional: Puedes inicializar las referencias aquí si el método Start no es necesario.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reproduce el sonido de explosión
        AudioManager.instance.PlaySound(splashSound);

        // Si la colisión es directa con un jugador
        if (collision.gameObject.CompareTag("player1") || collision.gameObject.CompareTag("player2"))
        {
            isDirectHit = true;
        }

        // Detecta todos los colliders dentro del radio de explosión
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radioExplosion);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("player1"))
            {
                PlayerBlink ninjaBlink = hitCollider.GetComponent<PlayerBlink>();
                if (ninjaBlink != null)
                {

                    if (isDirectHit)
                    {
                        ninjaBlink.Blink();
                        ninjaBlink.Blink();
                        ninjaBlink.Blink();
                        ninjaBlink.Blink();
                    }
                    else
                    {
                        ninjaBlink.Blink();
                        ninjaBlink.Blink();
                    }
                }
            }
            else if (hitCollider.CompareTag("player2"))
            {
                playerBlink2 ninja2Blink = hitCollider.GetComponent<playerBlink2>();
                if (ninja2Blink != null)
                {
                    // Aplica el efecto de Blink basado en si fue un golpe directo o en área
                    if (isDirectHit)
                    {
                        ninja2Blink.Blink();
                        ninja2Blink.Blink();
                        ninja2Blink.Blink();
                        ninja2Blink.Blink();
                    }
                    else
                    {
                        ninja2Blink.Blink();
                        ninja2Blink.Blink();
                    }
                }
            }
            
        }
        

        // Destruye la bala después de la explosión
        Destroy(gameObject);
    }
}
