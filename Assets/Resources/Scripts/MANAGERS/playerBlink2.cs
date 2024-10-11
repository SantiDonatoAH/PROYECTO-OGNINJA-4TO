using Photon.Pun;
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

    public GameObject healthI;
    public GameObject healthT;

    public Text txt2;
    public Image healthBar;
    public float healthAmount = 10f;
    public float restar = 0.5f;

    public Animator anim;

    public float total;

    public ParticleSystem bloodParticles2;

 
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
       
    }

    void Start()
    {
     
        Counter = GameObject.FindGameObjectWithTag("counter");

       
        counter = Counter.GetComponent<Counter>();

       
        normalColor = renderer.color;

        total = health;
    }

    void Update()
    {
        healthI = GameObject.FindGameObjectWithTag("Vida2");
        healthT = GameObject.FindGameObjectWithTag("txtV2");

        healthBar = healthI.GetComponent<Image>();
        txt2 = healthT.GetComponent<Text>();

        txt2.text = health.ToString();

    }

    [PunRPC]
    public void Blink()
    {
        photonView.RPC("ApplyDamage", RpcTarget.AllBuffered); // Llamada RPC para sincronizar el daño entre todas las sesiones

    }
    [PunRPC]
    public void ApplyDamage()
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
                counter.WIN1();
            }
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

    void TriggerBloodParticles()
    {
        if (bloodParticles2 != null)
        {
            bloodParticles2.Play();
        }
    }
    [PunRPC]
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
