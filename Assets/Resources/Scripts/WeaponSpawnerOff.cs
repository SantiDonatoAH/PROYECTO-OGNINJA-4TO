using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnerOff : MonoBehaviour
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
        //timer -= Time.deltaTime;
        //if (timer <= 0)
        //{
         //   SpawnWeapon();
         //   timer = 20;
        //}
    }
    void SpawnWeapon()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject armaSeleccionada = armas[Random.Range(0, armas.Length)];
        string prefabName = armaSeleccionada.name;
        GameObject objetoExistente = GameObject.Find(armaSeleccionada.name + "(Clone)");

        if (objetoExistente != null)
        {
            GameObject nuevaArma = Instantiate(armaSeleccionada, new Vector3(Random.Range(-6f, 6f), spawnPoint.position.y, 0f), spawnPoint.rotation);
            string newWeaponName = nuevaArma.name.Replace("(Clone)", "").Trim();
            Debug.Log(newWeaponName);


            // Obtener el script del objeto clonado y deshabilitarlo
            var tipoDelScript = System.Type.GetType(armaSeleccionada.name);
            var script = nuevaArma.GetComponent(tipoDelScript) as MonoBehaviour;

            script.enabled = false;

        }
        else
        {
            Instantiate(armaSeleccionada, new Vector3(Random.Range(-6, 6), spawnPoint.position.y, 0), spawnPoint.rotation);

        }
    }
}
