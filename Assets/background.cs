using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject dia;
    // Start is called before the first frame update
    void Start()
    {
        dia = GameObject.Find("dia(Clone)");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x + 0.0035f, transform.position.y);



        if (transform.position.x > 70 && dia == null)
        {
            transform.position = new Vector2(-81, transform.position.y);
        }

        else if (transform.position.x > 70 && dia != null)
        {
            transform.position = new Vector2(-26.4f, transform.position.y);
        }
    }
}
