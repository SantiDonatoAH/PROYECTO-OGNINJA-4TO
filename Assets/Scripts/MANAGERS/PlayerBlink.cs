using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBlink : MonoBehaviour
{
    SpriteRenderer renderer;
    SpriteRenderer renderer2;
    Color damageColor = Color.red;
    Color normalColor;
    public int health = 10;
    int health2;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer2 = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        normalColor = renderer.color;
        normalColor = renderer2.color;
    }

    public void Blink()
    {
        if (health > 0)
        {
            health -= 1;
            EnableBlink();
            Invoke("DisableBlink", 0.5f);

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void BlinkP2()
    {
        if (health > 0)
        {
            health -= 1;
            EnableBlink2();
            Invoke("DisableBlink2", 0.5f);

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void EnableBlink()
    {
        renderer.color = damageColor;
    }

    void DisableBlink()
    {
        renderer.color = normalColor;
    }  
    
    void EnableBlink2()
    {
        renderer2.color = damageColor;
    }

    void DisableBlink2()
    {
        renderer2.color = normalColor;
    }
}
