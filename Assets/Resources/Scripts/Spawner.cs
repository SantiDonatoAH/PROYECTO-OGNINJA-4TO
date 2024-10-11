using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject playerPrefab2;

    public Transform ninja1;
    public Transform ninja2;

    public GameObject kita;
    public GameObject kita2;

    public CombatManager combat;
    public abilitySelector ability;
    public deathBarrier death;
    public GameObject weapon;
    public GameObject reload;

    public GameObject panelInicio;

    private PhotonView photonView;

    public bool spawn = true;

    public GameObject vida; // Prefab del HUD de vida
    public Transform vidaT; // Posici�n donde se colocar� el HUD de vida

    public playerBlink2 blink2;
    public PlayerBlink blink;

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                // Instanciar el jugador 1
                PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);
            }
            else if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                // Instanciar el jugador 2
                PhotonNetwork.Instantiate(playerPrefab2.name, ninja2.position, ninja2.rotation);
            }
        }
        else
        {
            // Si no hay jugadores, mostrar el panel de inicio
            panelInicio.SetActive(true);
        }
    }



    void Update()
    {
        kita = GameObject.FindWithTag("player2");
        kita2 = GameObject.FindWithTag("player1");

      

        if (kita != null && kita2 !=null && spawn == true)
        {
            blink = kita2.GetComponent<PlayerBlink>();
            blink2 = kita.GetComponent<playerBlink2>();

            GameObject vidaInstanciada = PhotonNetwork.Instantiate(vida.name, vidaT.position, vidaT.rotation);
            vidaInstanciada.transform.SetParent(GameObject.Find("Game UI").transform, false);

            blink.enabled = true;
            blink2.enabled = true;

            PhotonNetwork.Instantiate(weapon.name, ninja2.position, ninja2.rotation);
            death.enabled = true;
            combat.enabled = true;
            PhotonNetwork.Instantiate(reload.name, ninja2.position, ninja2.rotation);
            spawn = false;
        }
    }

    // M�todo para instanciar el HUD de vida y sincronizar su estado


    // M�todo llamado para reducir la vida de manera sincronizada


    // Actualizar la barra de vida visualmente para todos los jugadores


    public void Volver()
    {
        SceneManager.LoadScene("INICIO");
    }
}