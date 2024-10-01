using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnmasVida()
    {
        Vida += 1;
        inputVida.text = Vida.ToString();
    }
    public void OnmenosVida()
    {
        Vida -= 1;
        inputVida.text = Vida.ToString();

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
        playerb.enabled = true;
        playerb2.enabled = true ;
        abilty.enabled = true;

        playerb.health = Vida;
        playerb2.health = Vida;
        abilty.Vida1 = Vida + 5;
        abilty.Vida2 = Vida + 5;
        panel.SetActive(false);
            }
}
