using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using JetBrains.Annotations;
using Photon.Pun;

public class abilitySelectorOff : MonoBehaviour
{
    public string[] abilities;

    public GameObject ninja1;
    public GameObject ninja2;

    public ninjaControllerOff ninjacontroller;
    public PlayerBlinkOff playerblink;

    public BombuchaOff bombucha;
    public FlotaflotaOff flotaflota;
    public MangueraOff manguera;
    public CombatManagerOff combatmanager;
    public PistolaOff pistola;
    public RocaOff roca;
    public SerpienteOff serpiente;
    public BoomerangOff boomerang;
    public LanzaOff lanza;

    public playerBlink2Off playerblink2;
    public ninjaController2Off ninjacontroller2;

    public habilidades habilidades;

    public string h1;
    public string h2;

    public Image image1;
    public Image image2;

    private float BombuchaC = .5f;

    private float FlotaflotaC = .375f;

    private float MangueraC = 0.05f;

    private float PistolaC = .175f;

    private float SerpienteC = .5f;

    private float BoomerangC = .5f;

    private float LanzaC = 0.06f;

    private float RocaC = .5f;

    public float Vida1 = 15;
    public float Vida2 = 15;

    public string newWeaponName;

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
            playerblink.health = Vida1;
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
            image1.sprite = Resources.Load<Sprite>("Cooldown"); // Carga la imagen correspondiente a "velocidad"

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Weapon"))
            {

                newWeaponName = obj.name.Replace("Off(Clone)", "").Trim();

                if (newWeaponName == "Bombucha")
                {
                    bombucha = obj.GetComponent<BombuchaOff>();
                    bombucha.cd1(BombuchaC);
                }
                else if (newWeaponName == "Flotaflota")
                {
                    flotaflota = obj.GetComponent<FlotaflotaOff>();
                    flotaflota.cd1(FlotaflotaC);
                }
                else if (newWeaponName == "Manguera")
                {
                    manguera = obj.GetComponent<MangueraOff>();
                    manguera.cd1(MangueraC);
                }
                
                else if (newWeaponName == "Pistola")
                {
                    pistola = obj.GetComponent<PistolaOff>();
                    pistola.cd1(PistolaC);
                }
                else if (newWeaponName == "Roca")
                {
                    roca = obj.GetComponent<RocaOff>();
                    roca.cd1(RocaC);
                }
                else if (newWeaponName == "Serpiente")
                {
                    serpiente = obj.GetComponent<SerpienteOff>();
                    serpiente.cd1(SerpienteC);
                }
                else if (newWeaponName == "Boomerang")
                {
                    boomerang = obj.GetComponent<BoomerangOff>();
                    boomerang.cd1(BoomerangC);
                }
                else if (newWeaponName == "Lanza")
                {
                    lanza = obj.GetComponent<LanzaOff>();
                    lanza.cd1(LanzaC);
                }
            }
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
            playerblink2.health = Vida2;
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
            image2.sprite = Resources.Load<Sprite>("Cooldown"); // Carga la imagen correspondiente a "velocidad"
            Debug.Log(2);
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Weapon"))
            {
                 newWeaponName = obj.name.Replace("Off(Clone)", "").Trim();
                Debug.Log(newWeaponName);

                if (newWeaponName == "Bombucha")
                {
                    bombucha = obj.GetComponent<BombuchaOff>();
                    bombucha.cd2(BombuchaC);
                }
                else if (newWeaponName == "Flotaflota")
                {
                    flotaflota = obj.GetComponent<FlotaflotaOff>();
                    flotaflota.cd2(FlotaflotaC);
                }
                else if (newWeaponName == "Manguera")
                {
                    manguera = obj.GetComponent<MangueraOff>();
                    manguera.cd2(MangueraC);
                }
                else if (newWeaponName == "Pistola")
                {
                    pistola = obj.GetComponent<PistolaOff>();
                    pistola.cd2(PistolaC);
                }
                else if (newWeaponName == "Roca")
                {
                    roca = obj.GetComponent<RocaOff>();
                    roca.cd2(RocaC);
                }
                else if (newWeaponName == "Serpiente")
                {
                    serpiente = obj.GetComponent<SerpienteOff>();
                    serpiente.cd2(SerpienteC);
                }
                else if (newWeaponName == "Boomerang")
                {
                    boomerang = obj.GetComponent<BoomerangOff>();
                    boomerang.cd2(BoomerangC);
                }
                else if (newWeaponName == "Lanza")
                {
                    lanza = obj.GetComponent<LanzaOff>();
                    lanza.cd2(LanzaC);
                }
            }
        }
    }
}
