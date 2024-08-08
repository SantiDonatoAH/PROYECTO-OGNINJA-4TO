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
        // Obtiene los componentes PlayerBlink y playerBlink2 de los GameObjects asignados
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
            anim.SetBool("IsPunching", true);
            if (IsInRange(ninja1, ninja2))
            {
                ninja2Blink.Blink();
            }
        }
        
            
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Ninja2 golpea a Ninja1
            if (IsInRange(ninja2, ninja1))
            {
                ninja1Blink.Blink();
            }
        }
    }


    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 1.5f; // Ajusta este valor según el rango de ataque
    }
}
