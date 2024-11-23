using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class texttoslide : MonoBehaviour
{
    public Text texto;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float valor = slider.value;
        texto.text = valor.ToString();
    }
}
