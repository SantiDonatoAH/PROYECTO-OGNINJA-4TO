using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Respawn;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Respawn = GameObject.FindWithTag("player1");
        rb = Respawn.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Respawn.transform.position = transform.position;
        rb.velocity = new Vector3(0, 0, 0);
    }
}
