using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using JetBrains.Annotations;
using Photon.Pun;

public class abilitySelector : MonoBehaviourPunCallbacks
{
    public string[] abilities;

    public GameObject ninja1;
    public GameObject ninja2;

    public NinjaController ninjacontroller;
    public PlayerBlink playerblink;

    public Bombucha bombucha;
    public Flotaflota flotaflota;
    public Manguera manguera;
    public CombatManager combatmanager;
    public Pistola pistola;

    public playerBlink2 playerblink2;
    public NinjaController2 ninjacontroller2;

    public habilidades habilidades;

    public string h1;
    public string h2;

    public GameObject im1;
    public GameObject im2;

    public GameObject Vida;
    public vidadeleter VidaD;

    public Image image1;
    public Image image2;

    public GameObject combat;

    private float BombuchaC = .5f;

    private float FlotaflotaC = .375f;

    private float MangueraC = 0.05f;

    private float PistolaC = .175f;

    public bool ranzo = true;

    // Start is called before the first frame update
    void Start()
    {
        im1 = GameObject.FindGameObjectWithTag("hab1");
        im2 = GameObject.FindGameObjectWithTag("hab2");

        ninja1 = GameObject.FindGameObjectWithTag("player1");
        ninja2 = GameObject.FindGameObjectWithTag("player2");

        image1 = im1.GetComponent<Image>();
        image2 = im2.GetComponent<Image>();

        combat = GameObject.FindGameObjectWithTag("combat");
        combatmanager = combat.GetComponent<CombatManager>();

        ninjacontroller = ninja1.GetComponent<NinjaController>();
        playerblink = ninja1.GetComponent<PlayerBlink>();

        ninjacontroller2 = ninja2.GetComponent<NinjaController2>();
        playerblink2 = ninja2.GetComponent<playerBlink2>();

        Vida = GameObject.FindGameObjectWithTag("Hposta");
        VidaD = Vida.GetComponent<vidadeleter>();

        Ninja1();
        Ninja2();



        // h1 = habilidades.habilidadesDropdown1.text;
    }

    // Update is called once per frame
    void Update()
    {

    }
    [PunRPC]
    void Ninja1()
    {
        h1 = abilities[Random.Range(0, abilities.Length)];

        Debug.Log(h1);

        if (h1 == "salto")
        {
           VidaD. photonView.RPC("Vida1", RpcTarget.All, "Salto");
            ninjacontroller.photonView.RPC("salto", RpcTarget.AllBuffered, 10); // Llamada
        }

        if (h1 == "vida")
        {
            VidaD.photonView.RPC("Vida1", RpcTarget.All, "Vida");
            playerblink.health = 15;
            playerblink.ranzo = true;
        }

        if (h1 == "daño")
        {
            VidaD.photonView.RPC("Vida1", RpcTarget.All, "Daño");
            playerblink2.photonView.RPC("Restar", RpcTarget.All, 0.75f); // Llamada RPC para sincronizar el daño entre todas las sesiones
        }

        if (h1 == "velocidad")
        {
            VidaD.photonView.RPC("Vida1", RpcTarget.All, "Velocidad");
            ninjacontroller.photonView.RPC("vel", RpcTarget.AllBuffered, 6.5f); // Llamada
        }

        if (h1 == "cooldown")
        {
            VidaD.photonView.RPC("Vida1", RpcTarget.All, "Cooldown");

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Weapon"))
            {
                PhotonView photonView = obj.GetComponent<PhotonView>();
                string weaponName = obj.name.Replace("(Clone)", "").Trim();
                float weaponValue = 0f;

                // Comparar el nombre y asignar el valor correspondiente
                switch (weaponName)
                {
                    case "Bombucha":
                        weaponValue = BombuchaC;
                        break;
                    case "Flotaflota":
                        weaponValue = FlotaflotaC;
                        break;
                    case "Manguera":
                        weaponValue = MangueraC;
                        break;
                    case "Pistola":
                        weaponValue = PistolaC;
                        break;
                   
                }

               
                    photonView.RPC("cd1", RpcTarget.AllBuffered, weaponValue);
                
            }

        }
    }

    [PunRPC]
    void Ninja2()
    {
        h2 = abilities[Random.Range(0, abilities.Length)];
        Debug.Log(h2);

        if (h2 == "salto")
        {
            VidaD.photonView.RPC("Vida2", RpcTarget.All, "Salto"); // Llamada
            ninjacontroller2.photonView.RPC("salto", RpcTarget.AllBuffered, 10); // Llamada
        }

        if (h2 == "vida")
        {
            VidaD.photonView.RPC("Vida2", RpcTarget.All, "Vida"); // Llamada
            playerblink2.photonView.RPC("Vida", RpcTarget.AllBuffered, 15f); // Llamada RPC para sincronizar el daño entre todas las sesiones


        }

        if (h2 == "daño")
        {
            VidaD.photonView.RPC("Vida2", RpcTarget.All, "Daño"); // Llamada
            playerblink.restar = .75f;
        }

        if (h2 == "velocidad")
        {
            VidaD.photonView.RPC("Vida2", RpcTarget.All, "Velocidad"); // Llamada
            ninjacontroller2.photonView.RPC("vel", RpcTarget.AllBuffered, 6.5f); // Llamada
        }

        if (h2 == "cooldown")
        {
            VidaD.photonView.RPC("Vida2", RpcTarget.All, "Cooldown"); // Llamada

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Weapon"))
            {
                PhotonView photonView = obj.GetComponent<PhotonView>();
                string weaponName = obj.name.Replace("(Clone)", "").Trim();
                float weaponValue = 0f;

                // Comparar el nombre y asignar el valor correspondiente
                switch (weaponName)
                {
                    case "Bombucha":
                        weaponValue = BombuchaC;
                        break;
                    case "Flotaflota":
                        weaponValue = FlotaflotaC;
                        break;
                    case "Manguera":
                        weaponValue = MangueraC;
                        break;
                    case "Pistola":
                        weaponValue = PistolaC;
                        break;

                }


                photonView.RPC("cd2", RpcTarget.AllBuffered, weaponValue);

            }

        }

    }
}
