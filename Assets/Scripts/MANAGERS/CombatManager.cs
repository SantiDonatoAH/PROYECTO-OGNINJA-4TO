using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PlayerBlink ninja1Blink;
    public playerBlink2 ninja2Blink;
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
            // Chequea si Ninja1 está golpeando a Ninja2
            if (IsInRange(ninja1, ninja2))
            {
                ninja2Blink.Blink();
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            // Chequea si Ninja2 está golpeando a Ninja1
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
