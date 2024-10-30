using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaRoca : MonoBehaviour
{
    private playerBlink2 ninja2Blink;
    private PlayerBlink ninjaBlink;


    private bool isDirectHit = false;

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
            ninjaBlink = collision.gameObject.GetComponent<PlayerBlink>();
            
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
        }

        if (collision.gameObject.CompareTag("player2"))
        {
            ninja2Blink = collision.gameObject.GetComponent<playerBlink2>();

            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
        }

        // Destruye la bala después de la explosión
        PhotonNetwork.Destroy(gameObject);
    }
}
