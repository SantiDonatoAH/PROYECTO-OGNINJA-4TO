using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerPrefab;
    public GameObject playerPrefab2;

    public Transform ninja1;
    public Transform ninja2;

    void Start()
    {
        // Verifica si el jugador es el creador de la sala (primer jugador en la lista)
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            // Si es el primer jugador, spawnea el playerPrefab en la posición del primer ninja
            PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);
        }
        else
        {
            // Si no, spawnea el playerPrefab2 en la posición del segundo ninja
            PhotonNetwork.Instantiate(playerPrefab2.name, ninja2.position, ninja2.rotation);
        }
    }
}
