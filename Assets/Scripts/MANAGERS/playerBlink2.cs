using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerBlink2 : MonoBehaviour
{
    SpriteRenderer renderer;
    Color damageColor = Color.red;
    Color normalColor;
    public float health = 10;
    public Text txt2;
    public Text pts1;
 public Image healthBar;
    public float healthAmount = 10f;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        txt2.text = health.ToString();
        normalColor = renderer.color;
    }

    public void Blink()
    {
        if (health > 0)
        {
            health -= 0.5f;
            txt2.text = health.ToString();
            healthAmount -= health;
            healthBar.fillAmount = healthAmount / 100f;
            EnableBlink();
            Invoke("DisableBlink", 0.5f);

            if (health <= 0)
            {
                int number = int.Parse(pts1.text);
                number ++ ;
                pts1.text = number.ToString();
                Debug.Log(pts1.text);
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
