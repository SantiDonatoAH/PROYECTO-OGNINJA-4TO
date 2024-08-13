using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject[] armas;
    public Transform[] spawnPoints;

    void Start()
    {
        SpawnWeapon();
    }

    void SpawnWeapon()
    {
        
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

       
        GameObject armaSeleccionada = armas[Random.Range(0, armas.Length)];

        
        Instantiate(armaSeleccionada, spawnPoint.position, spawnPoint.rotation);
    }
}
