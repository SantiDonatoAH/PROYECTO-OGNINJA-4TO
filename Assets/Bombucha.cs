using System.Collections;
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

    private bool canFire = true;  // Controla el cooldown para el primer jugador
    private bool canFire2 = true; // Controla el cooldown para el segundo jugador
    public float cooldownTime = 1f; // Tiempo de cooldown en segundos

    void Start()
    {
        GameObject ninja1 = GameObject.FindWithTag("player1");
        GameObject ninja2 = GameObject.FindWithTag("player2");

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetBool("IsHoldingBombucha") == true && Input.GetKeyDown(KeyCode.LeftShift) && canFire)
        {
            Fire();
        }

        if (anim2.GetBool("IsHoldingBombucha2") == true && Input.GetKeyDown(KeyCode.L) && canFire2)
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

        canFire = false; // Inicia el cooldown
        StartCoroutine(CooldownRoutine()); // Inicia el Coroutine para esperar 1.5 segundos
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

        canFire2 = false; // Inicia el cooldown para el segundo jugador
        StartCoroutine(CooldownRoutine2()); // Inicia el Coroutine para esperar 1.5 segundos para el segundo jugador
    }

    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        canFire = true; // Habilita el disparo nuevamente después de 1.5 segundos
    }

    IEnumerator CooldownRoutine2()
    {
        yield return new WaitForSeconds(cooldownTime);
        canFire2 = true; // Habilita el disparo nuevamente después de 1.5 segundos
    }
}
