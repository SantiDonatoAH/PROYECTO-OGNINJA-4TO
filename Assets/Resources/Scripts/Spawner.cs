using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject playerPrefab2;

    public Transform ninja1;
    public Transform ninja2;

    public GameObject kita;

    public CombatManager combat;
    public abilitySelector ability;
    public deathBarrier death;
    public WeaponSpawner weapon;

    public GameObject panelInicio;

    public Teleporter teleporter;

    public GameObject vida;
    public Transform vidaT;
    void Start()
    {
     
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            
            
        }
        else if (PhotonNetwork.PlayerList.Length > 1) 
        {

            GameObject vidaInstanciada = PhotonNetwork.Instantiate(vida.name, vidaT.position, vidaT.rotation);
            vidaInstanciada.transform.SetParent(GameObject.Find("Game UI").transform, false);

            PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);
            PhotonNetwork.Instantiate(playerPrefab2.name, ninja2.position, ninja2.rotation);

            
            
        }
        else if (PhotonNetwork.PlayerList.Length == 0)
        {
            panelInicio.SetActive  (true); 
        }
    }

    void Update()
    {

        kita = GameObject.FindWithTag("player2");
        if (kita != null)
        {
            weapon.enabled = true;

            death.enabled = true;

            ability.enabled = true;

            combat.enabled = true;

            teleporter.enabled = false;
        }
    }

    public void Volver()
    {
        SceneManager.LoadScene("INICIO");
    }

 
}
