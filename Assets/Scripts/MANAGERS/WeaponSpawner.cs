using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject[] armas;        // Array de armas que se pueden spawnear
    public Transform[] spawnPoints;   // Puntos de spawn en el mapa
    public float timer = 15f;         // Tiempo entre spawns
    public float armasSpawneadas = 2;

    void Start()
    {
        for (int i = 0; i < armasSpawneadas; i++)
        {
            SpawnWeapon();
        }
    }

    private void Update()
    {
        timer -= 0.01f;
        if (timer <= 0)
        {
            SpawnWeapon();
            timer = 25;
        }
    }
    void SpawnWeapon()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject armaSeleccionada = armas[Random.Range(0, armas.Length)];
        GameObject objetoExistente = GameObject.Find(armaSeleccionada.name + "(Clone)");

        if (objetoExistente != null)
        {
            // Instanciar el arma en el punto de spawn
            GameObject nuevaArma = Instantiate(armaSeleccionada, new Vector3(Random.Range(-6, 6), spawnPoint.position.y, 0), spawnPoint.rotation);

            // Obtener el script del objeto clonado y deshabilitarlo
            var tipoDelScript = System.Type.GetType(armaSeleccionada.name);
            var script = nuevaArma.GetComponent(tipoDelScript) as MonoBehaviour;    
            script.enabled = false;
            
        }
        else
        {
            // Si no existe un clon, simplemente instanciar el arma
            Instantiate(armaSeleccionada, new Vector3(Random.Range(-6, 6), spawnPoint.position.y, 0), spawnPoint.rotation);
        }
    }
}
