using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenesManager : MonoBehaviour
{
    public GameObject[] mapas;
    // Start is called before the first frame update
    void Start()
    {
        int mapasSelector = Random.Range(0, mapas.Length);

        if (mapasSelector == 0)
        {
            GameObject.Instantiate(mapas[0]);
        }
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
