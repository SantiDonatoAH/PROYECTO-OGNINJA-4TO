using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoundManager : MonoBehaviourPunCallbacks
{
    public GameObject[] mapas;
    public GameObject[] pisos;

    public WeaponSpawner ws;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("ws");


        if (weapon != null)
        {
            ws = weapon.GetComponent<WeaponSpawner>();

            int cuaren = Random.Range(0, mapas.Length);
            GameObject mapa = mapas[cuaren];
            GameObject piso = pisos[cuaren];

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.Instantiate(mapa.name, mapa.transform.position, mapa.transform.rotation);
                PhotonNetwork.Instantiate(piso.name, piso.transform.position, piso.transform.rotation);

                if (mapa.name == "dia")
                {
                    ws.photonView.RPC("SpawnWeaponD", RpcTarget.All);
                }
                else
                {
                    ws.photonView.RPC("SpawnWeaponN", RpcTarget.All);
                }

            }

            else
            {
                Instantiate(mapa, mapa.transform.position, mapa.transform.rotation);
                Instantiate(piso, piso.transform.position, piso.transform.rotation);
            }
        }
    }
       

    void Update()
    {
            
        }
    }

