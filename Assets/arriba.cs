using UnityEngine;
using System.Collections;
using System;

public class arriba : MonoBehaviour
{
    public Transform island;             // Transform de la isla que se moverá
    public float moveDistance = 3f;      // Distancia en el eje Y que se moverá la isla
    public float speed = 1f;             // Velocidad de movimiento de la isla

    private Vector3 originalPosition;    // Posición original de la isla
    private Vector3 topPosition;         // Posición en la parte superior

   // public GameObject arbol;
    //public GameObject[] pastos;

    void Start()
    {
        /*int cuaren = UnityEngine.Random.Range(0, 4);
        Debug.Log(cuaren);
        if (cuaren == 1) { arbol.SetActive(true); }
        if (cuaren == 2)
        {
            foreach (GameObject objeto in pastos)
            {

                objeto.SetActive(true);

            }
        }
        if (cuaren == 3)
        {
            arbol.SetActive(true); foreach (GameObject objeto in pastos)
            {

                objeto.SetActive(true);

            }
        }
        */
        // Define la posición original y la posición superior
        originalPosition = island.position;
        topPosition = originalPosition + new Vector3(0, moveDistance, 0);

        // Inicia el proceso de movimiento de la isla
        StartCoroutine(MoveIsland());
    }

    IEnumerator MoveIsland()
    {
        while (true)
        {
            // Mueve la isla a la posición superior
            yield return StartCoroutine(MoveToPosition(island, topPosition));

            // Espera un tiempo aleatorio en la posición superior
            float waitTime = 2.5f;
            yield return new WaitForSeconds(waitTime);

            // Mueve la isla de regreso a la posición original
            yield return StartCoroutine(MoveToPosition(island, originalPosition));

            // Espera un tiempo aleatorio en la posición original
            waitTime = 4f;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator MoveToPosition(Transform island, Vector3 targetPosition)
    {
        // Mueve la isla a la posición objetivo
        while (Vector3.Distance(island.position, targetPosition) > 0.1f)
        {
            island.position = Vector3.MoveTowards(island.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
