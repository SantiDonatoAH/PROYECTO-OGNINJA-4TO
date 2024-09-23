using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBlink : MonoBehaviour
{
    public Counter counter;
    public GameObject Counter;

    SpriteRenderer renderer;
    Color damageColor = Color.red;
    Color normalColor;
    public float health = 10;

    public GameObject healthI;
    public GameObject healthT;

    public Text txt1;
    public Image healthBar;
    public float healthAmount = 10f;
    public float restar = 0.5f;

    public Animator anim;

    public float total;

    public ParticleSystem bloodParticles;

    public Spawner spawner;

    public GameObject vida; // Prefab del HUD de vida
    public Transform vidaT; // Posición donde se colocará el HUD de vida

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        GameObject vidaInstanciada = PhotonNetwork.Instantiate(vida.name, vidaT.position, vidaT.rotation);
        vidaInstanciada.transform.SetParent(GameObject.Find("Game UI").transform, false);
    }

    void Start()
    {
        Counter = GameObject.FindGameObjectWithTag("counter");
        healthI = GameObject.FindGameObjectWithTag("Vida1");
        healthT = GameObject.FindGameObjectWithTag("txtV1");

        healthBar = healthI.GetComponent<Image>();
        txt1 = healthT.GetComponent<Text>();
        counter = Counter.GetComponent<Counter>();

        txt1.text = health.ToString();
        normalColor = renderer.color;

        total = health;
    }
    [PunRPC]

    public void Blink()
    {
        TriggerBloodParticles();

        if (health > 0)
        {
            anim.SetBool("IsBlinking", true);
            health -= restar;
            UpdateHealthBar();

            EnableBlink();
            Invoke("DisableBlink", 0.25f);
            if (health <= 0)
            {
                counter.WIN2();
            }
        }
    }
    [PunRPC]
    public void UpdateHealthBar()
    {
        txt1.text = health.ToString();
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

    void TriggerBloodParticles()
    {
        if (bloodParticles != null)
        {
            bloodParticles.Play();
        }
    }

    
}
