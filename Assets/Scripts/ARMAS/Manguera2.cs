using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manguera2 : MonoBehaviour
{
    public GameObject bala;
    public Transform firePoint2;
    public float bulletSpeed = 10f;
    private Animator anim;
    private CombatManager combatManager;
    public Transform Ninja2;
    public int multiplicador = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        combatManager = GetComponent<CombatManager>();
        // No es necesario desactivar la bala en el Start
    }

    void Update()
    {
        if (anim.GetBool("IsHoldingManguera") && Input.GetKeyDown(KeyCode.L))
        {
            Fire();
        }
    }

    void Fire()
    {

        if (Ninja2.rotation.y > 0) // Si el ninja está mirando hacia la izquierda
        {
            multiplicador = -1; // Cambia la dirección de disparo
        }
        else if (Ninja2.rotation.y == 0)
        {
            multiplicador = 1; // Dirección normal hacia la derecha
        }

        // Calcula la posición de la bala con base en el multiplicador
        Vector3 spawnPosition = firePoint2.position + (Vector3.right * 0.5f * multiplicador);
        GameObject nuevaBala = Instantiate(bala, spawnPosition, firePoint2.rotation);

        // Configura la dirección de la bala
        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint2.right * bulletSpeed;
    }
}