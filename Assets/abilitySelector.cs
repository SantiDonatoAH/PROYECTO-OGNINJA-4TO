using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilitySelector : MonoBehaviour
{
    public string[] abilities;

    public NinjaController ninjacontroller;
    public PlayerBlink playerblink;

    public Bombucha bombucha;
    
    public playerBlink2 playerblink2;
    public NinjaController2 ninjacontroller2;

    public habilidades habilidades;

    public string h1;
    public string h2;
    // Start is called before the first frame update
    void Start()
    {
        Ninja1();
        Ninja2();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Ninja1()
    {
        string habilidad = abilities[Random.Range(0, abilities.Length)];
        Debug.Log(habilidad);

        if (habilidad == "salto")
        {
            ninjacontroller.jumpForce = 10;
        }

        if (habilidad == "vida")
        {
            playerblink.health = 15;
        }

        if (habilidad == "daño")
        {
            playerblink2.restar = .75f;
        }

        if (habilidad == "velocidad")
        {
            ninjacontroller.moveSpeed = 6.5f;
        }
        if(habilidad == "cooldown")
        {
            bombucha.cooldownTime = .5f;
        }

    }

        void Ninja2() 
    {
        string habilidad = abilities[Random.Range(0, abilities.Length)];
        Debug.Log(habilidad);

        if (habilidad == "salto")
        {
            ninjacontroller2.jumpForce = 10;
        }

        if (habilidad == "vida")
        {
            playerblink2.health = 15;
        }

        if (habilidad == "daño")
        {
            playerblink.restar = .75f;
        }

        if (habilidad == "velocidad")
        {
            ninjacontroller2.moveSpeed = 6.5f;
        }
        if (habilidad == "cooldown")
        {
            bombucha.cooldownTime2 = .5f;
        }
    }
}
