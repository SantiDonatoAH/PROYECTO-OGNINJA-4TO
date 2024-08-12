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
        GameObject bullet = Instantiate(bala, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.velocity = transform.right * bulletSpeed * (GetComponent<SpriteRenderer>().flipX ? -1 : 1);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ninja2")
        {
            playerBlink2 ninja2 = collision.gameObject.GetComponent<playerBlink2>();
            if (ninja2 != null)
            {
                ninja2.Blink();
            }
            Destroy(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
