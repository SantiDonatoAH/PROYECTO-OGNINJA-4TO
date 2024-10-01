using Photon.Pun;
using UnityEngine;
using System.Collections;


public class CombatManager : MonoBehaviour
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
    public KnockbackManager KnockbackManager;

    public float cooldownTime = 0.5f;
    public float cooldownTime2 = 0.5f;

    private bool canFire = true;
    private bool canFire2 = true;

    public endAttack endAttack;
    public endAttack2 endAttack2;

    public PhotonView ninja1View;  // PhotonView de ninja1
    public PhotonView ninja2View;  // PhotonView de ninja2

    void Start()
    {
        // Asignar a ninja1 y ninja2 los objetos correspondientes
        ninja1 = GameObject.FindGameObjectWithTag("player1");
        ninja2 = GameObject.FindGameObjectWithTag("player2");

        // Obtener los PhotonView de los ninjas
        ninja1View = ninja1.GetComponent<PhotonView>();
        ninja2View = ninja2.GetComponent<PhotonView>();

        // Verificar si los PhotonView están asignados correctamente
        if (ninja1View == null || ninja2View == null)
        {
            Debug.LogError("PhotonView no encontrado en uno de los ninjas.");
        }

        // Obtener componentes de los ninjas
        ninja1Blink = ninja1.GetComponent<PlayerBlink>();
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        ninjaController = ninja1.GetComponent<NinjaController>();
        ninjaController2 = ninja2.GetComponent<NinjaController2>();

        anim = ninja1.GetComponent<Animator>();
        anim2 = ninja2.GetComponent<Animator>();

        endAttack = ninja1.GetComponent<endAttack>();
        endAttack2 = ninja2.GetComponent<endAttack2>();
    }

    void Update()
    {
    }

   

    public void HandleCombat()
    {
        if (pausemanager.ispaused == false)
        {
            if (ninjaController.isHoldingWeapon == false && canFire)
            {
                anim.SetBool("IsPunching", true);

                if (IsInRange(ninja1, ninja2) &&
                    ((ninja2.transform.position.x < ninja1.transform.position.x && ninja1.transform.rotation.eulerAngles.y > 0) ||
                    (ninja2.transform.position.x > ninja1.transform.position.x && ninja1.transform.rotation.eulerAngles.y < 100)))
                {
                    KnockbackManager.Ninja2();
                    StartCoroutine(CooldownRoutine());

                    // Llamar al RPC usando el PhotonView del ninja2 para sincronizar el daño
                    ninja2Blink.Blink();
                }
                StartCoroutine(endAttack.endAttack1());
            }

            
        }
    }

    public void HandleCombat2()
    {
        if (ninjaController2.isHoldingWeapon == false && canFire2)
        {
            anim2.SetBool("IsPunching", true);

            if (IsInRange(ninja2, ninja1) &&
                ((ninja1.transform.position.x < ninja2.transform.position.x && ninja2.transform.rotation.eulerAngles.y > 0) ||
                (ninja1.transform.position.x > ninja2.transform.position.x && ninja2.transform.rotation.eulerAngles.y < 100)))
            {
                KnockbackManager.Ninja1();
                StartCoroutine(CooldownRoutine2());

                // Llamar al RPC usando el PhotonView del ninja1 para sincronizar el daño
                ninja1Blink.Blink();
            }
            StartCoroutine(endAttack2.endAttack());
        }
    }

    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 1.5f;
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
