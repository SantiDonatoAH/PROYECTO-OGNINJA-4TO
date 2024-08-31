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
    string habilidad = abilities[Random.Range(0, abilities.Length)];
    Debug.Log(habilidad);

    if (habilidad == "salto")
    {
        image1.sprite = Resources.Load<Sprite>("Salto");
        ninjacontroller.jumpForce = 10;
    }

    if (habilidad == "vida")
    {
        image1.sprite = Resources.Load<Sprite>("Vida"); // Carga la imagen correspondiente a "vida"
        playerblink.health = 15;
    }

    if (habilidad == "daño")
    {
        image1.sprite = Resources.Load<Sprite>("Daño"); // Carga la imagen correspondiente a "daño"
        playerblink2.restar = .75f;
    }

    if (habilidad == "velocidad")
    {
        image1.sprite = Resources.Load<Sprite>("Velocidad"); // Carga la imagen correspondiente a "velocidad"
        ninjacontroller.moveSpeed = 6.5f;
    }
    
    if (habilidad == "cooldown")
    {
        image1.sprite = Resources.Load<Sprite>("Cooldown"); // Carga la imagen correspondiente a "cooldown"
        bombucha.cooldownTime = .5f;
    }
}

void Ninja2()
{
    string habilidad = abilities[Random.Range(0, abilities.Length)];
    Debug.Log(habilidad);

    if (habilidad == "salto")
    {
        image2.sprite = Resources.Load<Sprite>("Salto");
        ninjacontroller2.jumpForce = 10;
    }

    if (habilidad == "vida")
    {
        image2.sprite = Resources.Load<Sprite>("Vida"); // Carga la imagen correspondiente a "vida"
        playerblink2.health = 15;
    }

    if (habilidad == "daño")
    {
        image2.sprite = Resources.Load<Sprite>("Daño"); // Carga la imagen correspondiente a "daño"
        playerblink.restar = .75f;
    }

    if (habilidad == "velocidad")
    {
        image2.sprite = Resources.Load<Sprite>("Velocidad"); // Carga la imagen correspondiente a "velocidad"
        ninjacontroller2.moveSpeed = 6.5f;
    }

    if (habilidad == "cooldown")
    {
        image2.sprite = Resources.Load<Sprite>("Cooldown"); // Carga la imagen correspondiente a "cooldown"
        bombucha.cooldownTime2 = .5f;
    }
}

}
