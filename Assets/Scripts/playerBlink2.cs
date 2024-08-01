using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBlink2 : MonoBehaviour
{
    SpriteRenderer renderer;
    Color damageColor = Color.red;
    Color normalColor;
    public int health = 10;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        normalColor = renderer.color;
    }

    // Update is called once per frame
    public void Blink()
    {
        Invoke("EnableBlink", 0);
        Invoke("DisableBlink", 0.2f);
    }

    void EnableBlink()
    {
        renderer.color = damageColor;
        health -= 1;
    }

    void DisableBlink()
    {
        renderer.color = normalColor;
    }
}
