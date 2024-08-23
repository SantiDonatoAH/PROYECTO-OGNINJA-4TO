using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject[] armas;        // Array de armas que se pueden spawnear
    public Transform[] spawnPoints;   // Puntos de spawn en el mapa
    public float timer = 10f;         // Tiempo entre spawns

    void Start()
    {
        SpawnWeapon();
    }

    private void Update()
    {
        timer -= Time.deltaTime;  // Restar el tiempo pasado desde el último frame
        if (timer <= 0)
        {
            SpawnWeapon();        // Spawnear un arma cuando el tiempo llegue a 0
            timer = 10f;          // Reiniciar el temporizador
        }
    }

    void SpawnWeapon()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];  // Seleccionar un punto de spawn aleatorio
        GameObject armaSeleccionada = armas[Random.Range(0, armas.Length)];      // Seleccionar un arma aleatoria

        Instantiate(armaSeleccionada, spawnPoint.position, spawnPoint.rotation);  // Crear una nueva instancia del arma en el punto de spawn
    }
}
