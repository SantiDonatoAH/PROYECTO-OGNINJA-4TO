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

            // Llama a un RPC para desactivar el script en todos los clientes
            photonView.RPC("DisableScriptRPC", RpcTarget.All, nuevaArma.GetPhotonView().ViewID, armaSeleccionada.name);
        }
        else
        {
            PhotonNetwork.Instantiate(prefabName, new Vector3(Random.Range(-6, 6), spawnPoint.position.y, 0), spawnPoint.rotation);
        }
    }

    [PunRPC]
    void DisableScriptRPC(int viewID, string scriptName)
    {
        GameObject arma = PhotonView.Find(viewID).gameObject;
        var tipoDelScript = System.Type.GetType(scriptName);
        var script = arma.GetComponent(tipoDelScript) as MonoBehaviourPunCallbacks;
        if (script != null)
        {
            script.enabled = false;
        }
    }
}
