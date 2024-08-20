using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBlink : MonoBehaviour
{
    SpriteRenderer renderer;
    Color damageColor = Color.red;
    Color normalColor;
    public float health = 10;
    public Text txt1;
    public Text pts2;
    public Image healthBar;
    public float healthAmount = 10f;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        txt1.text = health.ToString();
        normalColor = renderer.color;
    }

    public void Blink()
    {
        if (health > 0)
        {
            health -= 0.5f;
            txt1.text = health.ToString();
            healthAmount = health; // Ajustar esta línea para que refleje correctamente la salud restante
            healthBar.fillAmount = healthAmount / 10f; // Cambia el divisor si la salud máxima no es 10

            EnableBlink();
            Invoke("DisableBlink", 0.5f);

            if (health <= 0)
            {
                int number = int.Parse(pts2.text);
                number++;
                pts2.text = number.ToString();
                Debug.Log(pts2.text);
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
