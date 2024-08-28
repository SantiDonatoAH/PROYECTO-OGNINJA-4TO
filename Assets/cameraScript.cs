using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject ninja1;
    public GameObject ninja2;

    private Rigidbody2D Ninja1rb;
    private Rigidbody2D Ninja2rb;

    public int offset = 7;
    // Start is called before the first frame update
    void Start()
    {
        Ninja1rb = ninja1.GetComponent<Rigidbody2D>();
        Ninja1rb = ninja2.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ninja1rb.position.y < -offset || Ninja1rb.position.x > offset || Ninja1rb.position.x < -offset)
        {
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }
    }
}
