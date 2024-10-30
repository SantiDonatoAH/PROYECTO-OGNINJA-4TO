using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingIslands : MonoBehaviour
{
    public Transform[] islands; // Array de islas que se moverán en círculo
    public float radius = 1f;   // Radio del movimiento circular
    public float speed = 1f;    // Velocidad de rotación

    private Vector3[] originalPositions; // Posiciones originales de cada isla

    void Start()
    {
        // Almacena las posiciones iniciales de cada isla
        originalPositions = new Vector3[islands.Length];
        for (int i = 0; i < islands.Length; i++)
        {
            originalPositions[i] = islands[i].position;
        }
    }

    void Update()
    {
        for (int i = 0; i < islands.Length; i++)
        {
            // Calcula el desplazamiento circular en el plano XZ
            float offsetX = Mathf.Cos(Time.time * speed + i) * radius;
            float offsetZ = Mathf.Sin(Time.time * speed + i) * radius;

            // Aplica el movimiento circular alrededor de la posición original
            islands[i].position = originalPositions[i] + new Vector3(offsetX, 0, offsetZ);
        }
    }
}
