using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter2 : MonoBehaviour
{
    public GameObject Respawn;
    public Rigidbody2D rb;
    public Vector2 kita;
    // Start is called before the first frame update
    void Start()
    {
        Respawn = GameObject.FindWithTag("player2");
        rb = Respawn.GetComponent<Rigidbody2D>();
        kita = Respawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Respawn.transform.position = kita;
        rb.velocity = new Vector3(0, 0, 0);
    }
}
