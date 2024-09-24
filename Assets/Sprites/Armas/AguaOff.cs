using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaOff : MonoBehaviour
{
    private playerBlink2Off ninja2Blink;
    private PlayerBlinkOff ninjaBlink;
    [SerializeField] private AudioClip ouchSound;

    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public GameObject ninja1;
    public GameObject ninja2;
    public GameObject combatManager;

    public KnockbackManager KnockbackManager;

    public Vector3 savedVelocity;

    void Start()
    {

        ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2Off>();

        ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlinkOff>();

        combatManager = GameObject.FindWithTag("combat");
        KnockbackManager = combatManager.GetComponent<KnockbackManager>();


        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();

        savedVelocity = GetComponent<Rigidbody2D>().velocity;
    }
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = savedVelocity;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("player2"))
        {
            Destroy(gameObject);

            ninja2Blink.Blink();
            KnockbackManager.Ninja2();
            StartCoroutine(ResetBlink(anim2));
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("player1"))
        {
            Destroy(gameObject);

            ninjaBlink.Blink();

            KnockbackManager.Ninja1();
            StartCoroutine(ResetBlink(anim2));
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("Weapon"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ResetBlink(Animator animator)
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsBlinking", false);
    }
}
