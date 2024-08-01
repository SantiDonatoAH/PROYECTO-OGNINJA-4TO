using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
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
        if (health != 0)
        {
            Invoke("EnableBlink", 0);
            Invoke("DisableBlink", 0.2f);
        }
        else
        {
            Debug.Log("poder");
        }
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
