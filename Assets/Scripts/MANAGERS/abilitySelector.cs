using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class abilitySelector : MonoBehaviour
{
    public string[] abilities;

    public NinjaController ninjacontroller;
    public PlayerBlink playerblink;

    public Bombucha bombucha;
    public Flotaflota flotaflota;
    public Manguera manguera;
    public CombatManager combatmanager;
    
    public playerBlink2 playerblink2;
    public NinjaController2 ninjacontroller2;

    public habilidades habilidades;

    public string h1;
    public string h2;

    public Image image1;
    public Image image2;

    // Start is called before the first frame update
    void Start()
    {
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
        bombucha.cooldownTime = .5f;
        flotaflota.cooldownTime = .375f;
        combatmanager.cooldownTime = .25f;
        manguera.cooldownTime = 0.05f;
        }
    else if (h1 != "cooldown")
        {
            bombucha.cooldownTime = 1f;
            flotaflota.cooldownTime = .75f;
            combatmanager.cooldownTime = .5f;
            manguera.cooldownTime = 0.085f;
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
        bombucha.cooldownTime2 = .5f;
        flotaflota.cooldownTime2 = .375f;
        combatmanager.cooldownTime2 = .25f;
        manguera.cooldownTime2 = 0.05f;
        }
        else if (h2 != "cooldown")
        {
            bombucha.cooldownTime2 = 1f;
            flotaflota.cooldownTime2 = .75f;
            combatmanager.cooldownTime2 = .5f;
            manguera.cooldownTime2 = 0.085f; ;
        }
    }

}
