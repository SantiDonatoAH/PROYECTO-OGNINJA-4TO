using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBombucha : MonoBehaviour
{
    private playerBlink2 ninja2Blink;
    private PlayerBlink ninjaBlink;

    [SerializeField] private AudioClip splashSound;

    public float explosionRadius = 2f;

    void Start()
    {
        GameObject ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        GameObject ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlink>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("player1"))
            {
                PlayerBlink ninjaBlink = hitCollider.GetComponent<PlayerBlink>();
                if (ninjaBlink != null)
                {
                    if (explosionRadius < 2)
                    {
                        // Radio menor a 2: 4 blinks
                        ninjaBlink.Blink();
                        ninjaBlink.Blink();
                        ninjaBlink.Blink();
                        ninjaBlink.Blink();
                        AudioManager.instance.PlaySound(splashSound);
                    }
                    else
                    {
                        // Radio mayor o igual a 2: 2 blinks
                        ninjaBlink.Blink();
                        ninjaBlink.Blink();
                        AudioManager.instance.PlaySound(splashSound);
                    }
                }
            }
            else if (hitCollider.CompareTag("player2"))
            {
                playerBlink2 ninja2Blink = hitCollider.GetComponent<playerBlink2>();
                if (ninja2Blink != null)
                {
                    if (explosionRadius < 2)
                    {
                        // Radio menor a 2: 4 blinks
                        ninja2Blink.Blink();
                        ninja2Blink.Blink();
                        ninja2Blink.Blink();
                        ninja2Blink.Blink();
                        AudioManager.instance.PlaySound(splashSound);
                    }
                    else
                    {
                        // Radio mayor o igual a 2: 2 blinks
                        ninja2Blink.Blink();
                        ninja2Blink.Blink();
                        AudioManager.instance.PlaySound(splashSound);
                    }
                }
            }
        }
        Destroy(gameObject);
    }
}
