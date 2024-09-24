using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class playerBlink2 : MonoBehaviourPunCallbacks, IPunObservable
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

    public GameObject vida; // Prefab del HUD de vida
    public Transform vidaT; // Posición donde se colocará el HUD de vida

    public Spawner spawner;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (photonView.IsMine) // Solo instanciar la barra de vida para el jugador local
        {
            GameObject vidaInstanciada = PhotonNetwork.Instantiate(vida.name, vidaT.position, vidaT.rotation);
            vidaInstanciada.transform.SetParent(GameObject.Find("Game UI").transform, false);
        }
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
    [PunRPC]

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
            UpdateHealthBar();
        }
    }
    [PunRPC]

    public void UpdateHealthBar()
    {
        txt2.text = health.ToString();
        healthAmount = health;
        healthBar.fillAmount = healthAmount / total;
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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) // Envía los datos del jugador local
        {
            stream.SendNext(health);
        }
        else // Recibe los datos del jugador remoto
        {
            health = (float)stream.ReceiveNext();
            UpdateHealthBar(); // Actualiza la barra de vida para los jugadores remotos
        }
    }

}
