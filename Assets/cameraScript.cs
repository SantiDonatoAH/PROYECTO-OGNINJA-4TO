using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject ninja1;
    public GameObject ninja2;

    private Rigidbody2D Ninja1rb;
    private Rigidbody2D Ninja2rb;

    public int maxoffset = 7;
    public int minoffset = -7;
    public int offsety = -5;
    // Start is called before the first frame update
    void Start()
    {
        Ninja1rb = ninja1.GetComponent<Rigidbody2D>();
        Ninja1rb = ninja2.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ninja1rb.position.y < offsety)
        {
            transform.position = new Vector3(transform.position.x, Ninja1rb.position.y, transform.position.z);
        }
        else if (Ninja1rb.position.x > maxoffset || Ninja1rb.position.x < minoffset)
        {
            transform.position = new Vector3(Ninja1rb.position.x, transform.position.y, transform.position.z);
        }

        else if (Ninja2rb.position.y < offsety)
        {
            transform.position = new Vector3(transform.position.x, Ninja2rb.position.y, transform.position.z);
        }
        else if (Ninja2rb.position.x > maxoffset || Ninja2rb.position.x < minoffset)
        {
            transform.position = new Vector3(Ninja2rb.position.x, transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(0, 0, 10);
        }
    }
}
