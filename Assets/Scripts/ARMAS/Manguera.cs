using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manguera : MonoBehaviour
{
    public GameObject bala;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    private Animator anim;
    private CombatManager combatManager;
    public Transform Ninja1;
    public int multiplicador = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        combatManager = GetComponent<CombatManager>();
        // No es necesario desactivar la bala en el Start
    }

    void Update()
    {
        if (anim.GetBool("IsHoldingManguera") && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Ajusta el multiplicador basado en la dirección del ninja
        if (Ninja1.rotation.y > 0) // Si el ninja está mirando hacia la izquierda
        {
            multiplicador = -1; // Cambia la dirección de disparo
        }
        else if (Ninja1.rotation.y == 0)
        {
            multiplicador = 1; // Dirección normal hacia la derecha
        }

        // Calcula la posición de la bala con base en el multiplicador
        Vector3 spawnPosition = firePoint.position + (Vector3.right * 0.5f * multiplicador);
        GameObject nuevaBala = Instantiate(bala, spawnPosition, firePoint.rotation);

        // Configura la dirección de la bala
        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }
}
