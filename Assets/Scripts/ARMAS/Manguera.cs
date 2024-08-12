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

    void Start()
    {
        anim = GetComponent<Animator>();
        combatManager = GetComponent<CombatManager>();
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
        
        GameObject nuevaBala = Instantiate(bala, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }
}
