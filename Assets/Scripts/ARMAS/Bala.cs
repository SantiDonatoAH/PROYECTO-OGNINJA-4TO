using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private playerBlink2 ninja2Blink;

    void Start()
    {
        // Encuentra el objeto con el tag "player2" en la escena y obtiene su componente playerBlink2
        GameObject ninja2 = GameObject.FindWithTag("player2");

        
            ninja2Blink = ninja2.GetComponent<playerBlink2>();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("player2"))
        {
            Destroy(gameObject);

            ninja2Blink.Blink();
            ninja2Blink.Blink();

        }
    }
}
