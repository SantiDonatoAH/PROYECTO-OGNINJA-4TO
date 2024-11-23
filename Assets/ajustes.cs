using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ajustes : MonoBehaviour
{
    public CounterOff counter;
    public PlayerBlinkOff playerb;
    public playerBlink2Off playerb2;
    public abilitySelectorOff abilty;

    public InputField inputVida;
    public InputField inputRondas;

    public GameObject panel;

    public int Vida = 10;
    public int Rondas = 3;

    public static ajustes instance;

    public RectTransform panelRectTransform;

    public Slider sliderV, sliderR, sliderD;

    public CounterOff coff;

    // Start is called before the first frame update
    void Awake()
    {
       
          
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void OnmasRondas()
    {
        Rondas += 1;
        inputRondas.text = Rondas.ToString();
    }

    public void OnmnemosRondas()
    {
        Rondas -= 1;
        inputRondas.text = Rondas.ToString();

    }

    public void OnHide() {
        float vida = sliderV.value;
        int rondas = (int)sliderR.value; // Resultado: 5
        float daño = sliderD.value;


        playerb.enabled = true;
        playerb2.enabled = true;
        abilty.enabled = true;
        coff.rondas(rondas)  ;

        playerb.health = vida;
        playerb2.health = vida;

        abilty.CambioV(vida + vida/2, vida);
        abilty.CambioD(daño + daño/ 2, daño);

        abilty.Ninja1();
        abilty.Ninja2();
        float panelWidth = panelRectTransform.rect.width;

        // Mueve el panel fuera de la pantalla hacia la izquierda
        panelRectTransform.anchoredPosition = new Vector2(-panelWidth, panelRectTransform.anchoredPosition.y);
    }
}
