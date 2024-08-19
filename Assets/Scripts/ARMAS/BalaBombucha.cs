using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBombucha : MonoBehaviour
{
    private playerBlink2 ninja2Blink;
    private PlayerBlink ninjaBlink;

    [SerializeField] private AudioClip splashSound;

    public float radioExplosion = 2;

    void Start()
    {
        GameObject ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        GameObject ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlink>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        
            if (collision.gameObject.CompareTag("player1"))
            {
            Destroy(gameObject);

            ninjaBlink.Blink();
                        ninjaBlink.Blink();
                        AudioManager.instance.PlaySound(splashSound);
                    
                
            }
            if (collision.gameObject.CompareTag("player2"))
            {
            Destroy(gameObject);
            ninja2Blink.Blink();
                        ninja2Blink.Blink();
                        AudioManager.instance.PlaySound(splashSound);
                    }
                
            
        
        Destroy(gameObject);
    }
}
