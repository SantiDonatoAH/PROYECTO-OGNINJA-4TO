using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private playerBlink2 ninja2Blink;
    private PlayerBlink ninjaBlink;
    [SerializeField] private AudioClip ouchSound;

    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public GameObject ninja1;
    public GameObject ninja2;

    private KnockbackManager ninja1KnockbackManager;
    private KnockbackManager ninja2KnockbackManager;
    void Start()
    {

         ninja2 = GameObject.FindWithTag("player2");
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

         ninja1 = GameObject.FindWithTag("player1");
        ninjaBlink = ninja1.GetComponent<PlayerBlink>();

        ninja1KnockbackManager = ninja1.GetComponent<KnockbackManager>();
        ninja2KnockbackManager = ninja2.GetComponent<KnockbackManager>();

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("player2"))
        {
            Destroy(gameObject);

            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2Blink.Blink();
            ninja2KnockbackManager.PlayFeedback(ninja1);
            anim2.SetBool("IsBlinking", true);
            StartCoroutine(ResetBlink(anim2));
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("player1"))
        {
            Destroy(gameObject);

            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninjaBlink.Blink();
            ninja1KnockbackManager.PlayFeedback(ninja2);
            anim.SetBool("IsBlinking", true);
            StartCoroutine(ResetBlink(anim2));
            AudioManager.instance.PlaySound(ouchSound);
        }

        else if (collision.gameObject.CompareTag("Weapon"))
        {

        }
        else { Destroy(gameObject); }
    }

    IEnumerator ResetBlink(Animator animator)
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsBlinking", false);
    }
}
