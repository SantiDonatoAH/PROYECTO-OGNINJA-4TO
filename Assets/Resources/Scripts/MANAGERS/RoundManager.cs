using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public GameObject[] mapas;
    // Start is called before the first frame update
    void Start()
    {
        Object.Instantiate(mapas[Random.Range(0, mapas.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
