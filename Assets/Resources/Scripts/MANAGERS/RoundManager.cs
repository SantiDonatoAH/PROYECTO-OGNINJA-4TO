using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoundManager : MonoBehaviourPunCallbacks
{
    public GameObject[] mapas;
    public GameObject[] pisos;

    public WeaponSpawner ws;
    public WeaponSpawnerOff wsO;
    public GameObject weapon;
    public GameObject mapa;

    public abilitySelectorOff ab;

    private bool ranzo = true;
    // Start is called before the first frame update
    void Start()
    {
            int cuaren = Random.Range(0, mapas.Length);
             mapa = mapas[cuaren];
            GameObject piso = pisos[cuaren];

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(mapa.name, mapa.transform.position, mapa.transform.rotation);
            PhotonNetwork.Instantiate(piso.name, piso.transform.position, piso.transform.rotation);
        }
        else
        {
            Instantiate(mapa, mapa.transform.position, mapa.transform.rotation);
            Instantiate(piso, piso.transform.position, piso.transform.rotation);
        }
    }


    void Update()
    {
        weapon = GameObject.FindGameObjectWithTag("ws");
    if (weapon != null == ranzo == true)
    {
            if (PhotonNetwork.IsConnected)
            {
                ws = weapon.GetComponent<WeaponSpawner>();

                if (mapa.name == "dia")
                {
                    ws.SpawnWeaponD();
                }
                else
                {
                    ws.SpawnWeaponN();
                }
            }

            else
            {
                wsO = weapon.GetComponent<WeaponSpawnerOff>();

                if (mapa.name == "dia")
                {
                    wsO.SpawnWeaponD();
                    wsO.SpawnWeaponD();
                }
                else
                {
                    wsO.SpawnWeaponN();
                    wsO.SpawnWeaponN();
                }
            }
            ranzo = false;
            ab.enabled = true;
        }

    }
}

