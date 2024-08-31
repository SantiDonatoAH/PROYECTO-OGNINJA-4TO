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

    private KnockbackManager ninja1KnockbackManager;
    private KnockbackManager ninja2KnockbackManager;

    void Start()
    {
        
        ninja1Blink = ninja1.GetComponent<PlayerBlink>();
        ninja2Blink = ninja2.GetComponent<playerBlink2>();

        ninjaController = ninja1.GetComponent<NinjaController>();
        ninjaController2 = ninja2.GetComponent<NinjaController2>();

        
        ninja1KnockbackManager = ninja1.GetComponent<KnockbackManager>();
        ninja2KnockbackManager = ninja2.GetComponent<KnockbackManager>();
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
                    ninja2KnockbackManager.PlayFeedback(ninja1);
                    anim2.SetBool("IsBlinking", true);
                    StartCoroutine(ResetBlink(anim2));  
                }
            }

            if (Input.GetKeyDown(KeyCode.L) && ninjaController2.isHoldingWeapon == false)
            {
                anim2.SetBool("IsPunching", true);
                if (IsInRange(ninja2, ninja1))
                {
                    ninja1Blink.Blink();
                    ninja1KnockbackManager.PlayFeedback(ninja2);
                    anim.SetBool("IsBlinking", true);  
                    StartCoroutine(ResetBlink(anim));  
                }
            }
        }
    }

    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 1.5f; 
    }

    void endAttack1()
    {
        anim.SetBool("IsPunching", false);
    }

    void endAttack2()
    {
        anim2.SetBool("IsPunching", false);
    }

    IEnumerator ResetBlink(Animator animator)
    {
        yield return new WaitForSeconds(0.1f);  
        animator.SetBool("IsBlinking", false);  
    }
}
