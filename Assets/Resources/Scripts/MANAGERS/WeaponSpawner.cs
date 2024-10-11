 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeaponSpawner : MonoBehaviourPunCallbacks
{
    public GameObject[] armas;        // Array de armas que se pueden spawnear
    public Transform[] spawnPoints;   // Puntos de spawn en el mapa
    public float timer = 20f;         // Tiempo entre spawns
    public float armasSpawneadas = 1;

    void Start()
    {
        for (int i = 0; i < armasSpawneadas; i++)
        {
            SpawnWeapon();
        }
    }

    private void Update()
    {
      
    }

    void SpawnWeapon()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject armaSeleccionada = armas[Random.Range(0, armas.Length)];
        string prefabName = armaSeleccionada.name;
        GameObject objetoExistente = GameObject.Find(armaSeleccionada.name + "(Clone)");

        if (objetoExistente != null)
        {
            GameObject nuevaArma = PhotonNetwork.Instantiate(prefabName, new Vector3(Random.Range(-6f, 6f), spawnPoint.position.y, 0f), spawnPoint.rotation);



            // Obtener el script del objeto clonado y deshabilitarlo
            var tipoDelScript = System.Type.GetType(armaSeleccionada.name);
            var script = nuevaArma.GetComponent(tipoDelScript) as MonoBehaviourPunCallbacks;    
            script.enabled = false;
            
        }
        else
        {
            PhotonNetwork.Instantiate(prefabName, new Vector3(Random.Range(-6, 6), spawnPoint.position.y, 0), spawnPoint.rotation);

        }
    }
}
