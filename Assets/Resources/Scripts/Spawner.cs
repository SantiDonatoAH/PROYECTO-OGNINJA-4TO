using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour
{

    public Text txt1;
    public Text txt2;

    public int pts1;
    public int pts2;

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
        pts2 = int.Parse(txt2.text);
        pts1 = int.Parse(txt1.text);
        // Verifica si el jugador es el creador de la sala (primer jugador en la lista)
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            GameObject vidaInstanciada = PhotonNetwork.Instantiate(vida.name, vidaT.position, vidaT.rotation);
            vidaInstanciada.transform.SetParent(GameObject.Find("Game UI").transform, false); 
            
            PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);
            teleporter.enabled = true;
            
        }
        else if (PhotonNetwork.PlayerList.Length > 1) 
        {
            if (pts1 > 0 && pts2 > 0)
            {
                GameObject vidaInstanciada = PhotonNetwork.Instantiate(vida.name, vidaT.position, vidaT.rotation);
                vidaInstanciada.transform.SetParent(GameObject.Find("Game UI").transform, false);

                PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);
            }

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
