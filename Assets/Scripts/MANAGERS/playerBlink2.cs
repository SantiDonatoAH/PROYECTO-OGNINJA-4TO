using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerBlink2 : MonoBehaviour
{
    SpriteRenderer renderer;
    Color damageColor = Color.red;
    Color normalColor;
    public int health = 20;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        normalColor = renderer.color;
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
                Debug.Log("Gano el jugadort 1");
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
