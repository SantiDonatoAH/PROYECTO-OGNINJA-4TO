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
    private int totalBlinks2 = 0;
    private int totalBlinks3 = 0;

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
            if (SceneManager.GetActiveScene().name == "PRINCIPAL")
            {
                if (totalBlinks >= 10)
                {
                    Debug.Log("Gano el jugador 2");
                    SceneManager.LoadScene("SEGUNDO");
                }
            }
            else if (SceneManager.GetActiveScene().name == "SEGUNDO")
            {
                if (totalBlinks2 >= 10)
                {
                    Debug.Log("Gano el jugador 1");
                    SceneManager.LoadScene("TERCERO");
                }
            }
            else if (SceneManager.GetActiveScene().name == "TERCERO")
            {
                if (totalBlinks3 >= 10)
                {
                    Debug.Log("Gano el jugador 1");
                    SceneManager.LoadScene("GAMEOVER");
                }
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
