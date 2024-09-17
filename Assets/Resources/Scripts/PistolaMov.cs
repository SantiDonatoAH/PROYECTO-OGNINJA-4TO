using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaMov : MonoBehaviour
{
    public Rigidbody2D rb;
    public int poder = 0;

    public Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (poder != 0)
        {
            rb.velocity = Vector2.zero; // Asegúrate de que no tenga velocidad
            rb.angularVelocity = 0f;
            transform.position = new Vector2(transform.position.x, pos.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            poder = 2;
            pos = new Vector2(transform.position.x, transform.position.y);
        }

    }
}
