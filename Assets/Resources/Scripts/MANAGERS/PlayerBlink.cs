using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBlink : MonoBehaviourPunCallbacks, IPunObservable
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

    public GameObject vida; // Prefab del HUD de vida
    public Transform vidaT; // Posición donde se colocará el HUD de vida

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
        if (health > 0)
        {
            TriggerBloodParticles();
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

    public void ApplyDamage()
    {
        photonView.RPC("Blink", RpcTarget.AllBuffered); // Llamada RPC para sincronizar el daño entre todas las sesiones
    }

    [PunRPC]
    public void UpdateHealthBar()
    {
        txt1.text = health.ToString();
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

    void TriggerBloodParticles()
    {
        if (bloodParticles != null)
        {
            bloodParticles.Play();
        }
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
