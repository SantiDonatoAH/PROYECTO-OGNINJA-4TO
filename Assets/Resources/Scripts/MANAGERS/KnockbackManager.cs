using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackManager : MonoBehaviour
{
    public Rigidbody2D Ninja;
    public Rigidbody2D Ninja22;

    public GameObject ninja1;
    public GameObject ninja2;

    [SerializeField]
    private float strength = 16, delay = 0.25f;


    private IEnumerator Reset1()
    {
        yield return new WaitForSeconds(delay);
        //  Ninja.velocity = Vector2.zero;
    }

    private IEnumerator Reset2()
    {
        yield return new WaitForSeconds(delay);
        // Ninja22.velocity = Vector2.zero;
    }

    public void Ninja1()
    {
       /* StopAllCoroutines();
        Vector2 direction = (transform.position - ninja2.transform.position).normalized;
        Ninja.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(Reset1());  */
    }

    public void Ninja2()
    {
       /* StopAllCoroutines();
        Vector2 direction = (transform.position - ninja1.transform.position).normalized;
        Ninja22.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(Reset2()); */

    }
}