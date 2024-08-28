using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject secondPanel;

    // Start is called before the first frame update
    void Start()
    {
        secondPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickStart()
    {
        secondPanel.SetActive(true);
    }

}
