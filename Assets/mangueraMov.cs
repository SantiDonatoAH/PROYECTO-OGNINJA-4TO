using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mangueraMov : MonoBehaviour
{
    public Vector3 pos;
    public float timer = 2f;         // Tiempo entre spawns

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 0.01f;
        if (timer <= 0)
        {
            tp();
            timer = .1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

    }

    void tp()
    {
        transform.position = pos;
    }
}
