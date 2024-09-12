using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

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

    void Start()
    {
        // Verifica si el jugador es el creador de la sala (primer jugador en la lista)
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            // Si es el primer jugador, spawnea el playerPrefab en la posición del primer ninja
            PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);

        }
        else if (PhotonNetwork.PlayerList.Length > 1) 
        {
            PhotonNetwork.Instantiate(playerPrefab2.name, ninja2.position, ninja2.rotation);

            playerPrefab.transform.position = ninja1.position;
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
        }
    }

    public void Volver()
    {
        SceneManager.LoadScene("INICIO");
    }
}
