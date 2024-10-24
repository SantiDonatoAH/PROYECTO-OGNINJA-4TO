using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrierOff : MonoBehaviour
{
    private playerBlink2Off ninja2Blink;
    private PlayerBlinkOff ninjaBlink;

    public int blinks = 50;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2Off>();

        GameObject ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlinkOff>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player1"))
        {
            for (int i = 0; i < blinks; i++)
            {
                ninjaBlink.Blink();
            }

        }
        if (collision.gameObject.CompareTag("player2"))
        {
            for (int i = 0; i < blinks; i++)
            {
                ninja2Blink.Blink();
            }
        }
    }
}
