using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBlink : MonoBehaviour
{
    public Counter counter;

    SpriteRenderer renderer;
    Color damageColor = Color.red;
    Color normalColor;
    public float health = 10;
    public Text txt1;
    public Image healthBar;
    public float healthAmount = 10f;
    public float restar = 0.5f;

    public float total;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        txt1.text = health.ToString();
        normalColor = renderer.color;

        total = health;
    }

    public void Blink()
    {
        if (health > 0)
        {
            health -= restar;
            txt1.text = health.ToString();
            healthAmount = health; // Ajustar esta línea para que refleje correctamente la salud restante
            healthBar.fillAmount = healthAmount / total; // Cambia el divisor si la salud máxima no es 10

            EnableBlink();
            Invoke("DisableBlink", 0.5f);

            if (health <= 0)
            {
                counter.WIN2();
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
