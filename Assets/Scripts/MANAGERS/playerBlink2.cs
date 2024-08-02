using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerBlink2 : MonoBehaviour
{
    SpriteRenderer renderer;
    Color damageColor = Color.red;
    Color normalColor;
    public int health = 10;
    private int totalBlinks = 0;

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
            Invoke("DisableBlink", 0.5f);
        }
        else
        {
            totalBlinks++;
            if (totalBlinks == 1)
            {
                Debug.Log("Gano el jugador 2");
            }

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
