using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject ninja1;
    public GameObject ninja2;
    private PlayerBlink ninja1Blink;
    private playerBlink2 ninja2Blink;
    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;

    void Start()
    {
        ninja1Blink = ninja1.GetComponent<PlayerBlink>();
        ninja2Blink = ninja2.GetComponent<playerBlink2>();
    }

    void Update()
    {
        HandleCombat();
    }

    void HandleCombat()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Punch"); 
            if (IsInRange(ninja1, ninja2))
            {
                ninja2Blink.Blink();
            }
        }
        anim.ResetTrigger("Punch");
        
    }

    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 1.5f;
    }
}
