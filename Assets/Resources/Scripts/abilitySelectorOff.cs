using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using JetBrains.Annotations;

public class abilitySelectorOff : MonoBehaviour
{
    public string[] abilities;

    public GameObject ninja1;
    public GameObject ninja2;

    public ninjaControllerOff ninjacontroller;
    public PlayerBlinkOff playerblink;

    public Bombucha bombucha;
    public Flotaflota flotaflota;
    public Manguera manguera;
    public CombatManagerOff combatmanager;
    public Pistola pistola;

    public playerBlink2Off playerblink2;
    public ninjaController2Off ninjacontroller2;

    public habilidades habilidades;

    public string h1;
    public string h2;

    public Image image1;
    public Image image2;

    private float bombuchaC = .5f;
    private float bombuchaN = 1f;

    private float flotaflotaC = .375f;
    private float flotaflotaN = .75f;

    private float mangueraC = 0.05f;
    private float mangueraN = 0.03f;

    private float combatmanagerC = .25f;
    private float combatmanagerN = .5f;

    private float pistolaC = .175f;
    private float pistolaN = .3f;

    // Start is called before the first frame update
    void Start()
    {
        ninja1 = GameObject.FindGameObjectWithTag("player1");
        ninja2 = GameObject.FindGameObjectWithTag("player2");

       

        Ninja1();
        Ninja2();


        // h1 = habilidades.habilidadesDropdown1.text;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Ninja1()
    {
        h1 = abilities[Random.Range(0, abilities.Length)];

        Debug.Log(h1);

        if (h1 == "salto")
        {
            image1.sprite = Resources.Load<Sprite>("Salto");
            ninjacontroller.jumpForce = 10;
        }

        if (h1 == "vida")
        {
            image1.sprite = Resources.Load<Sprite>("Vida"); // Carga la imagen correspondiente a "vida"
            playerblink.health = 15;
        }

        if (h1 == "daño")
        {
            image1.sprite = Resources.Load<Sprite>("Daño"); // Carga la imagen correspondiente a "daño"
            playerblink2.restar = .75f;
        }

        if (h1 == "velocidad")
        {
            image1.sprite = Resources.Load<Sprite>("Velocidad"); // Carga la imagen correspondiente a "velocidad"
            ninjacontroller.moveSpeed = 6.5f;
        }

        if (h1 == "cooldown")
        {
            image1.sprite = Resources.Load<Sprite>("Cooldown"); // Carga la imagen correspondiente a "cooldown"
            bombucha.cooldownTime = bombuchaC;
            flotaflota.cooldownTime = flotaflotaC;
            combatmanager.cooldownTime = combatmanagerC;
            manguera.sumador = mangueraC;
            pistola.cooldownTime = pistolaC;
        }
        else if (h1 != "cooldown")
        {
            bombucha.cooldownTime = bombuchaN;
            flotaflota.cooldownTime = flotaflotaN;
            combatmanager.cooldownTime = combatmanagerN;
            manguera.sumador = mangueraN;
            pistola.cooldownTime = pistolaN;
        }
    }

    void Ninja2()
    {
        h2 = abilities[Random.Range(0, abilities.Length)];
        Debug.Log(h2);

        if (h2 == "salto")
        {
            image2.sprite = Resources.Load<Sprite>("Salto");
            ninjacontroller2.jumpForce = 10;
        }

        if (h2 == "vida")
        {
            image2.sprite = Resources.Load<Sprite>("Vida"); // Carga la imagen correspondiente a "vida"
            playerblink2.health = 15;
        }

        if (h2 == "daño")
        {
            image2.sprite = Resources.Load<Sprite>("Daño"); // Carga la imagen correspondiente a "daño"
            playerblink.restar = .75f;
        }

        if (h2 == "velocidad")
        {
            image2.sprite = Resources.Load<Sprite>("Velocidad"); // Carga la imagen correspondiente a "velocidad"
            ninjacontroller2.moveSpeed = 6.5f;
        }

        if (h2 == "cooldown")
        {
            image2.sprite = Resources.Load<Sprite>("Cooldown"); // Carga la imagen correspondiente a "cooldown"
            bombucha.cooldownTime2 = bombuchaC;
            flotaflota.cooldownTime2 = flotaflotaC;
            combatmanager.cooldownTime2 = combatmanagerC;
            manguera.sumador2 = mangueraC;
            pistola.cooldownTime2 = pistolaC;
        }
        else if (h2 != "cooldown")
        {
            bombucha.cooldownTime2 = bombuchaN;
            flotaflota.cooldownTime2 = flotaflotaN;
            combatmanager.cooldownTime2 = combatmanagerN;
            manguera.sumador2 = mangueraN;
            pistola.cooldownTime2 = pistolaN;
        }
    }

}
