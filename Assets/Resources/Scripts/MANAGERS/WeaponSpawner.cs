using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeaponSpawner : MonoBehaviourPunCallbacks
{
    public GameObject[] armas;        // Array de armas que se pueden spawnear
    public Transform[] spawnPoints;   // Puntos de spawn en el mapa
    public float timer = 20f;         // Tiempo entre spawns
    public float armasSpawneadas = 0;
    public static WeaponSpawner instance;

    void Start()
    {
        SpawnWeapon(); 
        SpawnWeapon();
}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Destruir esta instancia si ya existe otra
            return;  // Salir del Awake para evitar ejecutar el código en la instancia destruida
        }
    }

    [PunRPC]
    void SpawnWeapon()
    {
        if (armas.Length == 0) return; // Si no hay armas, salir de la función

        // Convertir el array armas en una lista
        List<GameObject> listaArmas = new List<GameObject>(armas);

        // Seleccionar un arma y un punto de spawn aleatorio
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject armaSeleccionada = listaArmas[Random.Range(0, listaArmas.Count)];
        string prefabName = armaSeleccionada.name;

        // Comprobar si ya existe un objeto del mismo tipo
        GameObject objetoExistente = GameObject.Find(armaSeleccionada.name + "(Clone)");

        // Instanciar el arma si no existe
        if (objetoExistente == null)
        {
            PhotonNetwork.Instantiate(prefabName, new Vector3(Random.Range(-6, 6), spawnPoint.position.y, 0), spawnPoint.rotation);

            // Eliminar el arma seleccionada de la lista
            listaArmas.Remove(armaSeleccionada);

            // Convertir la lista de vuelta a un array si es necesario
            armas = listaArmas.ToArray();
        }
    }
}
