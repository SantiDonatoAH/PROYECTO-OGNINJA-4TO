using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotaflota : MonoBehaviourPunCallbacks
{

    public GameObject ninja1;
    public GameObject ninja2;

    private PlayerBlink ninja1Blink;
    private playerBlink2 ninja2Blink;

    private NinjaController ninjaController;
    private NinjaController2 ninjaController2;

    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    public ScreenController pausemanager;

    private bool canFire = true;
    private bool canFire2 = true;

    public float cooldownTime = .75f;
    public float cooldownTime2 = .75f;

    PhotonView view;
    PhotonView view2;
    // Start is called before the first frame update
    void Start()
    {
        ninja1 = GameObject.FindWithTag("player1");
        ninja2 = GameObject.FindWithTag("player2");


        ninja1Blink = ninja1.GetComponent<PlayerBlink>();
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        ninjaController = ninja1.GetComponent<NinjaController>();
        ninjaController2 = ninja2.GetComponent<NinjaController2>();

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();

        view = ninja1.GetComponent<PhotonView>();
        view2 = ninja2.GetComponent<PhotonView>();
    }

[PunRPC]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && anim.GetBool("IsHoldingFlotaflota") == true && canFire && view.IsMine)
        {
            anim.SetBool("IsAttacking", true);
            if (IsInRange(ninja1, ninja2))
            {
                ninja2Blink.Blink();
                ninja2Blink.Blink();
                ninja2Blink.Blink();
                ninja2Blink.Blink();
                ninja2Blink.Blink();
            }
            canFire = false;
            StartCoroutine(CooldownRoutine());
        }

        if (Input.GetKeyDown(KeyCode.L) && anim2.GetBool("IsHoldingFlotaflota2") == true && canFire2 && view2.IsMine)
        {
            anim2.SetBool("IsAttacking", true);
            if (IsInRange(ninja2, ninja1))
            {
                ninja1Blink.Blink();
                ninja1Blink.Blink();
                ninja1Blink.Blink();
                ninja1Blink.Blink();
                ninja1Blink.Blink();
            }
            canFire2 = false; // Inicia el cooldown para el segundo jugador
            StartCoroutine(CooldownRoutine2());
        }
    }

    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 2.5f;
    }

    void endAttack1()
    {
        anim.SetBool("IsAttacking", false);
    }
    void endAttack2()
    {
        anim2.SetBool("IsAttacking", false);
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
