using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MangueraOff : MonoBehaviour
{

    public Rigidbody2D rb;

    public GameObject agua;
    public float bulletSpeed = 10f;

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
    public float cooldownTime = 0.085f;
    public float cooldownTime2 = 0.085f;

    public float sumador = 0.02f;
    public float sumador2 = 0.02f;

    public float poder = 0f;
    public float poder2 = 0f;

    void Start()
    {
        ninja1 = GameObject.FindWithTag("player1");

        ninja2 = GameObject.FindWithTag("player2");

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();
    }

    void Update()
    {

        if (anim.GetBool("IsHoldingManguera") == true && Input.GetKey(KeyCode.LeftShift) && canFire)
        {
            poder += sumador;
            if (poder >= 8.1f)
            {
                poder = 8.1f;
            }
        }
        else if (anim.GetBool("IsHoldingManguera") == true && Input.GetKeyUp(KeyCode.LeftShift))
        {
            Fire();
        }

        if (anim2.GetBool("IsHoldingManguera2") == true && Input.GetKey(KeyCode.L) && canFire2)
        {
            poder2 += sumador2;
            if (poder2 >= 8.1f)
            {
                poder2 = 8.1f;
            }

        }
        else if (anim2.GetBool("IsHoldingManguera2") == true && Input.GetKeyUp(KeyCode.L))
        {
            Fire2();
        }

    }


    void Fire()
    {
        StartCoroutine(FireWithCooldown());
    }

    IEnumerator FireWithCooldown()
    {
        AudioManager.instance.PlaySound(pewSound);

        for (int i = 0; i < poder; i++)
        {
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

            rb = nuevaBala.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.right * bulletSpeed;

            yield return new WaitForSeconds(cooldownTime);
        }

        poder = 0;

    }
    void Fire2()
    {

        StartCoroutine(FireWithCooldown2());
    }


    IEnumerator FireWithCooldown2()
    {
        AudioManager.instance.PlaySound(pewSound);

        for (int i = 0; i < poder2; i++)
        {
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

            rb = nuevaBala.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.right * bulletSpeed;

            yield return new WaitForSeconds(cooldownTime2);
        }
        poder2 = 0;

    }

    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
    }

    IEnumerator CooldownRoutine2()
    {
        yield return new WaitForSeconds(cooldownTime2);

    }

}