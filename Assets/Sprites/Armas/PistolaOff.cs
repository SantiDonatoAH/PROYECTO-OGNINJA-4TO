using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaOff : MonoBehaviour
{

    public Rigidbody2D rb;

    public GameObject bala;
    public float bulletSpeed = 10f;

    public Animator anim;
    public Animator anim2;
    public GameObject ninja1;
    public GameObject ninja2;

    public int multiplicador = 0;
    public int multiplicador2 = 0;

    [SerializeField] private AudioClip pewSound;

    private bool canFire = true;  // Controla el cooldown para el primer jugador
    private bool canFire2 = true; // Controla el cooldown para el segundo jugador
    public float cooldownTime = .3f;
    public float cooldownTime2 = .3f;

    public ScreenController pausemanager;

    void Start()
    {
        ninja1 = GameObject.FindWithTag("player1");

        ninja2 = GameObject.FindWithTag("player2");

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();
    }

    void Update()
    {

        if (anim.GetBool("IsHoldingPistola") == true && Input.GetKeyDown(KeyCode.LeftShift) && canFire)
        {
            Fire();
        }

        if (anim2.GetBool("IsHoldingPistola2") == true && Input.GetKeyDown(KeyCode.L) && canFire2)
        {
            Fire2();
        }

    }

    void Fire()
    {
        Transform firePoint = ninja1.GetComponent<Transform>();

        if (firePoint.rotation.y == 0)
        {
            multiplicador = 1; // Direcci�n normal hacia la derecha
        }

        else if (firePoint.rotation.y != 0) // Si el ninja est� mirando hacia la izquierda
        {
            multiplicador = -1; // Cambia la direcci�n de disparo
        }

        GameObject nuevaBala = Instantiate(bala, new Vector3(firePoint.position.x + (0.5f * multiplicador), firePoint.position.y, 0), firePoint.rotation);

        rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
        AudioManager.instance.PlaySound(pewSound);

        canFire = false; // Inicia el cooldown
        StartCoroutine(CooldownRoutine()); // Inicia el Coroutine para esperar 1.5 segundos
    }

    void Fire2()
    {
        Transform firePoint2 = ninja2.GetComponent<Transform>();

        if (firePoint2.rotation.y != 0) // Si el ninja est� mirando hacia la izquierda
        {
            multiplicador2 = -1; // Cambia la direcci�n de disparo
        }
        else if (firePoint2.rotation.y == 0)
        {
            multiplicador2 = 1; // Direcci�n normal hacia la derecha
        }

        GameObject nuevaBala = Instantiate(bala, new Vector3(firePoint2.position.x + (0.5f * multiplicador2), firePoint2.position.y, 0), firePoint2.rotation);

        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint2.right * bulletSpeed;
        AudioManager.instance.PlaySound(pewSound);

        canFire2 = false; // Inicia el cooldown para el segundo jugador
        StartCoroutine(CooldownRoutine2()); // Inic
    }

    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        canFire = true; // Habilita el disparo nuevamente despu�s de 1.5 segundos
    }

    IEnumerator CooldownRoutine2()
    {
        yield return new WaitForSeconds(cooldownTime2);
        canFire2 = true; // Habilita el disparo nuevamente despu�s de 1.5 segundos
    }

}