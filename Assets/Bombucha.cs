using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombucha : MonoBehaviour
{
    public GameObject bala;
    public float bulletSpeed = 10f;

    public Animator anim;
    public Animator anim2;

    public int multiplicador = 0;
    public int multiplicador2 = 0;

    public ScreenController pausemanager;

    void Start()
    {
        GameObject ninja1 = GameObject.FindWithTag("player1");

        GameObject ninja2 = GameObject.FindWithTag("player2");

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetBool("IsHoldingBombucha") == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Fire();
        }

        if (anim2.GetBool("IsHoldingBombucha") == true && Input.GetKeyDown(KeyCode.L))
        {
            Fire2();
        }
    }

    void Fire()
    {
        GameObject ninja1 = GameObject.FindWithTag("player1");
        Transform firePoint = ninja1.GetComponent<Transform>();

        if (firePoint.rotation.y == 0)
        {
            multiplicador = 1; // Dirección normal hacia la derecha
        }

        else if (firePoint.rotation.y != 0) // Si el ninja está mirando hacia la izquierda
        {
            multiplicador = -1; // Cambia la dirección de disparo
        }

        GameObject nuevaBala = Instantiate(bala, new Vector3(firePoint.position.x + (0.5f * multiplicador), firePoint.position.y, 0), firePoint.rotation);

        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }

    void Fire2()
    {
        GameObject ninja2 = GameObject.FindWithTag("player2");
        Transform firePoint2 = ninja2.GetComponent<Transform>();

        if (firePoint2.rotation.y != 0) // Si el ninja está mirando hacia la izquierda
        {
            multiplicador2 = -1; // Cambia la dirección de disparo
        }
        else if (firePoint2.rotation.y == 0)
        {
            multiplicador2 = 1; // Dirección normal hacia la derecha
        }

        GameObject nuevaBala = Instantiate(bala, new Vector3(firePoint2.position.x + (0.5f * multiplicador2), firePoint2.position.y, 0), firePoint2.rotation);

        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint2.right * bulletSpeed;
    }
}