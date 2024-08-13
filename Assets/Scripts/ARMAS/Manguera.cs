using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manguera : MonoBehaviour
{
    public GameObject bala;
    public float bulletSpeed = 10f;

    private Transform firePoint;
    private Transform firePoint2;

    private Animator anim;
    private Animator anim2;

    private CombatManager combatManager;
    private NinjaController ninjaController;

    public int multiplicador = 0;

    public ScreenController pausemanager;

    void Start()
    {
        GameObject ninja1 = GameObject.FindWithTag("player1");
        firePoint = ninja1.GetComponent<Transform>();

        GameObject ninja2 = GameObject.FindWithTag("player2");
        firePoint2 = ninja2.GetComponent<Transform>();

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();
        combatManager = GetComponent<CombatManager>();
    }

    void Update()
    {
        if (anim.GetBool("IsHoldingManguera") == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Fire();
        }

        if (anim2.GetBool("IsHoldingManguera") && Input.GetKeyDown(KeyCode.L))
        {
            Fire2();
        }
    }

    void Fire()
    {

        if (firePoint.rotation.y == 180) // Si el ninja está mirando hacia la izquierda
        {
            Debug.Log("ki");

            multiplicador = -1; // Cambia la dirección de disparo
        }
        else if (firePoint.rotation.y == 0)
        {
            Debug.Log("ki");

            multiplicador = 1; // Dirección normal hacia la derecha
        }
        GameObject nuevaBala = Instantiate(bala, new Vector3(firePoint.position.x + (0.5f * multiplicador), firePoint.position.y, 0), firePoint.rotation);

        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }

    void Fire2()
    {
        if (firePoint2.rotation.y > 0) // Si el ninja está mirando hacia la izquierda
        {

            multiplicador = -1; // Cambia la dirección de disparo
        }
        else if (firePoint2.rotation.y == 0)
        {

            multiplicador = 1; // Dirección normal hacia la derecha
        }

        Vector3 spawnPosition = firePoint2.position + (Vector3.right * 0.5f * multiplicador);
        GameObject nuevaBala = Instantiate(bala, spawnPosition, firePoint2.rotation);

        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint2.right * bulletSpeed;
    }
}