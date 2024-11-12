using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

public class LanzaOff : MonoBehaviourPunCallbacks
{

    public Rigidbody2D rb;

    public GameObject agua;
    public float bulletSpeed = 4f;

    public Animator anim;
    public Animator anim2;
    public GameObject ninja1;
    public GameObject ninja2;

    public int multiplicador = 0;
    public int multiplicador2 = 0;

    [SerializeField] private AudioClip pewSound;

    public ScreenController pausemanager;

    public bool canFire = true;  // Controla el cooldown para el primer jugador
    public bool canFire2 = true; // Controla el cooldown para el segundo jugador
    public float cooldownTime = 0.25f;
    public float cooldownTime2 = 0.25f;

    public float sumador = 0.035f;
    public float sumador2 = 0.035f;

    public float poder = 0f;
    public float poder2 = 0f;

  
    void Start()
    {
        ninja1 = GameObject.FindWithTag("player1");

        ninja2 = GameObject.FindWithTag("player2");

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();

    }

    public void cd1(float cd)
    {
        sumador = cd;
    }
    public void cd2(float cd)
    {
        sumador2 = cd;
    }

    void Update()
    {

        if (anim.GetBool("IsHoldingLanza") == true && Input.GetKey(KeyCode.LeftShift) && canFire)
        {
            poder += sumador;
            if (poder >= 6.1f)
            {
                poder = 6.1f;
            }
        }
        else if (anim.GetBool("IsHoldingLanza") == true && Input.GetKeyUp(KeyCode.LeftShift) )
        {
            Fire();
            poder = 0;
        }

        if (anim2.GetBool("IsHoldingLanza2") == true && Input.GetKey(KeyCode.L) && canFire2 )
        {
            poder2 += sumador2;
            if (poder2 >= 6.1f)
            {
                poder2 = 6.1f;
            }

        }
        else if (anim2.GetBool("IsHoldingLanza2") == true && Input.GetKeyUp(KeyCode.L))
        {
            Fire2();
            poder2 = 0;
        }

    }


    void Fire()
    {
        canFire = false;
        Transform firePoint = ninja1.GetComponent<Transform>();

        if (firePoint.rotation.y == 0)
        {
            multiplicador = 1; // Dirección normal hacia la derecha
        }
        else if (firePoint.rotation.y != 0) // Si el ninja está mirando hacia la izquierda
        {
            multiplicador = -1; // Cambia la dirección de disparo
        }

        GameObject nuevaBala = Instantiate(agua, new Vector3(firePoint.position.x + (0.5f * multiplicador), firePoint.position.y, 0), firePoint.rotation);

        // Asigna un tag o propiedad a la bala que indique quién la disparó
        BalaRocaOff balaScript = nuevaBala.GetComponent<BalaRocaOff>();
        if (balaScript != null)
        {
            balaScript.shooterTag = "player1"; // Marca la bala con el tag del disparador
        }

        rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed * poder;
        StartCoroutine(CooldownRoutine());
    }

    void Fire2()
    {
        canFire2 = false;
        Transform firePoint = ninja2.GetComponent<Transform>();

        if (firePoint.rotation.y == 0)
        {
            multiplicador = 1; // Dirección normal hacia la derecha
        }
        else if (firePoint.rotation.y != 0) // Si el ninja está mirando hacia la izquierda
        {
            multiplicador = -1; // Cambia la dirección de disparo
        }

        GameObject nuevaBala = Instantiate(agua, new Vector3(firePoint.position.x + (0.5f * multiplicador), firePoint.position.y, 0), firePoint.rotation);

        // Asigna un tag o propiedad a la bala que indique quién la disparó
        BalaRocaOff balaScript = nuevaBala.GetComponent<BalaRocaOff>();
        if (balaScript != null)
        {
            balaScript.shooterTag = "player2"; // Marca la bala con el tag del disparador
        }

        rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed * poder2;
        StartCoroutine(CooldownRoutine2());
    }




    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        canFire = true;
    }

    IEnumerator CooldownRoutine2()
    {
        yield return new WaitForSeconds(cooldownTime2);
        canFire2 = true;
    }

}