using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private playerBlink2 ninja2Blink;
    private PlayerBlink ninjaBlink;
    void Start()
    {
       
        GameObject ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        GameObject ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlink>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("player2"))
        {
            Destroy(gameObject);

            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();

        }
    }
}
