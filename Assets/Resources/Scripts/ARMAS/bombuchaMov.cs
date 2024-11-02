using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bombuchaMov : MonoBehaviourPunCallbacks
{
    public Rigidbody2D rb;
    public int poder = 0;

    public Vector2 pos;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

   

   
}
