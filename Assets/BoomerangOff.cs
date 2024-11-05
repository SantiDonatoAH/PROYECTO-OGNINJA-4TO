using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangOff : MonoBehaviourPunCallbacks
{

    public Rigidbody2D rb;

    public GameObject bala;

    public Rigidbody2D rb2;

    public GameObject bala2;
    public float bulletSpeed = 15f;

    [SerializeField] private AudioClip whoosh1;
    [SerializeField] private AudioClip whoosh2;
    [SerializeField] private AudioClip whoosh3;

    private AudioClip[] whooshSounds;

    public Animator anim;
    public Animator anim2;
    public GameObject ninja1;
    public GameObject ninja2;

    public int multiplicador = 0;
    public int multiplicador2 = 0;

    

    private bool canFire = true;  // Controla el cooldown para el primer jugador
    private bool canFire2 = true; // Controla el cooldown para el segundo jugador
    public float cooldownTime = .75f;
    public float cooldownTime2 = .75f;

    public ScreenController pausemanager;

   
    public void cd1(float cd)
    {
        cooldownTime = cd;
    }
    public void cd2(float cd)
    {
        cooldownTime2 = cd;
    }

    void Start()
    {
        ninja1 = GameObject.FindWithTag("player1");
        ninja2 = GameObject.FindWithTag("player2");

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();

        whooshSounds = new AudioClip[] { whoosh1, whoosh2, whoosh3 };

    }

    void Update()
    {

        if (anim.GetBool("IsHoldingBoomerang") == true && Input.GetKeyDown(KeyCode.LeftShift) && canFire)
        {
            Fire();
            
        }

        if (anim2.GetBool("IsHoldingBoomerang2") == true && Input.GetKeyDown(KeyCode.L) && canFire2)
        {
            Fire2();
            
        }

    }

    void Fire()
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

        GameObject nuevaBala = Instantiate(bala, new Vector3(firePoint.position.x + (0.5f * multiplicador), firePoint.position.y, 0), firePoint.rotation);

        rb = nuevaBala.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
        AudioClip randomWhooshSound = whooshSounds[Random.Range(0, whooshSounds.Length)];
        AudioManager.instance.PlaySound(randomWhooshSound);

        canFire = false; // Inicia el cooldown
        StartCoroutine(CooldownRoutine()); // Inicia el Coroutine para esperar 1.5 segundos
    }

    void Fire2()
    {
        Transform firePoint2 = ninja2.GetComponent<Transform>();

        if (firePoint2.rotation.y != 0) // Si el ninja está mirando hacia la izquierda
        {
            multiplicador2 = -1; // Cambia la dirección de disparo
        }
        else if (firePoint2.rotation.y == 0)
        {
            multiplicador2 = 1; // Dirección normal hacia la derecha
        }

        GameObject nuevaBala2 = Instantiate(bala2, new Vector3(firePoint2.position.x + (0.5f * multiplicador2), firePoint2.position.y, 0), firePoint2.rotation);

        Rigidbody2D rb2 = nuevaBala2.GetComponent<Rigidbody2D>();
        rb2.velocity = firePoint2.right * bulletSpeed;
        AudioClip randomWhooshSound = whooshSounds[Random.Range(0, whooshSounds.Length)];
        AudioManager.instance.PlaySound(randomWhooshSound);

        canFire2 = false; // Inicia el cooldown para el segundo jugador
        StartCoroutine(CooldownRoutine2()); // Inic
    }

    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        canFire = true; // Habilita el disparo nuevamente después de 1.5 segundos
    }

    IEnumerator CooldownRoutine2()
    {
        yield return new WaitForSeconds(cooldownTime2);
        canFire2 = true; // Habilita el disparo nuevamente después de 1.5 segundos
    }

}