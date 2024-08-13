using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        // Obtiene los componentes PlayerBlink y playerBlink2 de los GameObjects asignados
        ninja1Blink = ninja1.GetComponent<PlayerBlink>();
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        ninjaController = ninja1.GetComponent<NinjaController>();
        ninjaController2 = ninja2.GetComponent<NinjaController2>();
    }

    void Update()
    {
        HandleCombat();
    }

    void HandleCombat()
    {
        if (pausemanager.ispaused == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && ninjaController.isHoldingWeapon == false)
            {
                anim.SetBool("IsPunching", true);
                if (IsInRange(ninja1, ninja2))
                {
                    ninja2Blink.Blink();
                }
            }

            if (Input.GetKeyDown(KeyCode.L) && ninjaController2.isHoldingWeapon == false)
            {
                anim2.SetBool("IsPunching", true);
                if (IsInRange(ninja2, ninja1))
                {
                    ninja1Blink.Blink();
                }
            }
        }
    }


    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 1.5f; // Ajusta este valor según el rango de ataque
    }

    void endAttack1()
    {
        anim.SetBool("IsPunching", false);
    }
    void endAttack2()
    {
        anim2.SetBool("IsPunching", false);
    }
}

