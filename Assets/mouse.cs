using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouse : MonoBehaviour
{
    public Text hint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        hint.enabled = true;    }
    void OnMouseExit()
    {
        hint.enabled = false;
    }

}
