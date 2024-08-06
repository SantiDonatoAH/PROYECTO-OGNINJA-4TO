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
                // Maneja la muerte del ninja aquí, por ejemplo, reiniciando la escena
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
}
