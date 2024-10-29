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
    public GameObject mapa;
    // Start is called before the first frame update
    void Start()
    {

            int cuaren = Random.Range(0, mapas.Length);
             mapa = mapas[cuaren];
            GameObject piso = pisos[cuaren];


                PhotonNetwork.Instantiate(mapa.name, mapa.transform.position, mapa.transform.rotation);
                PhotonNetwork.Instantiate(piso.name, piso.transform.position, piso.transform.rotation);

                

            

           
        
    }
       

    void Update()
    {
        weapon = GameObject.FindGameObjectWithTag("ws");
    if (weapon != null)
    {
        ws = weapon.GetComponent<WeaponSpawner>(); }
        if (mapa.name == "dia")
        {
            ws.SpawnWeaponD();
        }
        else
        {
            ws.SpawnWeaponN();
        }
    }
}

