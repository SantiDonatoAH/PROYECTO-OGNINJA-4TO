using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class playerBlink2Off : MonoBehaviour
{
    public Counter counter;
    public GameObject Counter;

    SpriteRenderer renderer;
    Color damageColor = Color.red;
    Color normalColor;
    public float health = 10;
    public Text txt2;

    public GameObject healthI;
    public GameObject healthT;

    public Image healthBar;
    public float healthAmount = 10f;
    public float restar = 0.5f;

    public Animator anim;

    public float total;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        healthI = GameObject.FindGameObjectWithTag("Vida2");
        healthT = GameObject.FindGameObjectWithTag("txtV2");
        Counter = GameObject.FindGameObjectWithTag("counter");

        healthBar = healthI.GetComponent<Image>();
        txt2 = healthT.GetComponent<Text>();
        counter = Counter.GetComponent<Counter>();

        txt2.text = health.ToString();
        normalColor = renderer.color;

        total = health;
    }

    public void Blink()
    {
        if (health > 0)
        {
            anim.SetBool("IsBlinking", true);
            health -= restar;
            UpdateHealthBar();

            EnableBlink();
            Invoke("DisableBlink", 0.25f);

            if (health <= 0)
            {
                counter.WIN1();
            }
        }
    }

    public void UpdateHealthBar()
    {
        txt2.text = health.ToString();
        healthAmount = health;
        healthBar.fillAmount = healthAmount / total; // Actualizar la barra de vida
    }

    void EnableBlink()
    {
        renderer.color = damageColor;
    }

    void DisableBlink()
    {
        renderer.color = normalColor;
        anim.SetBool("IsBlinking", false);
    }
}
