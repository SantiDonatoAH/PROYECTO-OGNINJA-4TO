using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PlayerBlink BlinkScript;
    public GameObject ninja1;
    public GameObject ninja2;

    void Update()
    {
        HandleCombat();
    }

    void HandleCombat()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            if (IsInRange(ninja1, ninja2))
            {
                BlinkScript.BlinkP2();
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            
            if (IsInRange(ninja2, ninja1))
            {
                BlinkScript.Blink();
            }
        }
    }

    bool IsInRange(GameObject attacker, GameObject target)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);
        return distance < 5f; 
    }
}
