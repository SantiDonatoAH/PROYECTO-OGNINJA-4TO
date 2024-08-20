using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject[] armas;
    public Transform[] spawnPoints;
    public float timer = 10;

    void Start()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject armaSeleccionada = armas[Random.Range(0, armas.Length)];
        Instantiate(armaSeleccionada, spawnPoint.position, spawnPoint.rotation);

    }

    private void Update()
    {
        timer -= 0.01f;
        if (timer <= 0)
        {
            SpawnWeapon();
        }
    }

    void SpawnWeapon()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];


        GameObject armaSeleccionada = armas[Random.Range(0, armas.Length)];


        Instantiate(armaSeleccionada, spawnPoint.position, spawnPoint.rotation);

        Debug.Log(timer);
        timer = 10;
        Debug.Log(timer);
    }
}
