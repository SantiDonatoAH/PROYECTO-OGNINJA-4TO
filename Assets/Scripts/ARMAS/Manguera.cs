using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manguera : MonoBehaviour
{
    public GameObject bala;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    private Animator anim;
    public Transform ninja1;
    public Transform ninja2;
    public int multiplicador = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        // No es necesario desactivar la bala en el Start
    }

    void Update()
    {
        // Detecta cuál ninja está usando la manguera y dispara en consecuencia
        if (anim.GetBool("IsHoldingManguera") && Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Detecta la dirección del ninja que está usando la manguera
        if (ninja1.GetComponent<NinjaController>().derecha)
        {
            multiplicador = 1;
        }
        else
        {
            multiplicador = -1;
        }

        // Calcula la posición de la bala con base en el multiplicador
        Vector3 spawnPosition = firePoint.position + (Vector3.right * 0.5f * multiplicador);
        GameObject nuevaBala = Instantiate(bala, spawnPosition, firePoint.rotation);

        // Configura la dirección de la bala
        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed * multiplicador;
    }
}
