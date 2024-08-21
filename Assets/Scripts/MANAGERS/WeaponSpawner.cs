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
        GameObject objetoExistente = GameObject.Find(armaSeleccionada.name + "(Clone)");

        if (objetoExistente != null)
        {
            // Si ya fue instanciado, mueve el objeto existente a x = 2
            objetoExistente.transform.position = spawnPoint.position;
        }
        else
        {
            // Si no ha sido instanciado, instancia el objeto
            Instantiate(armaSeleccionada, spawnPoint.position, spawnPoint.rotation);
        }

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
        GameObject objetoExistente = GameObject.Find(armaSeleccionada.name + "(Clone)");

        if (objetoExistente != null)
        {
            // Si ya fue instanciado, mueve el objeto existente a x = 2
            objetoExistente.transform.position = spawnPoint.position;
        }
        else
        {
            // Si no ha sido instanciado, instancia el objeto
            Instantiate(armaSeleccionada, new Vector3 (Random.Range(-6, 6), spawnPoint.position.y), spawnPoint.rotation);
        }
        timer = 10;
        Debug.Log(timer);
    }
}
