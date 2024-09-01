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
    public float strength = 40; 
    public float delay = 0.25f;

    private IEnumerator Reset1()
    {
        yield return new WaitForSeconds(delay);
        Ninja.velocity = Vector2.zero;
    }

    private IEnumerator Reset2()
    {
        yield return new WaitForSeconds(delay);
        Ninja22.velocity = Vector2.zero;
    }

    public void Ninja1()
    {
        StopAllCoroutines();
        // Calcula la dirección en el eje X y ajusta el valor en Y a cero
        Vector2 direction = new Vector2(transform.position.x - ninja2.transform.position.x, 0);
        Ninja.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(Reset1());
    }

    public void Ninja2()
    {
        StopAllCoroutines();
        // Calcula la dirección en el eje X y ajusta el valor en Y a cero
        Vector2 direction = new Vector2(transform.position.x - ninja1.transform.position.x, 0);
        Ninja22.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(Reset2());
    }
}
