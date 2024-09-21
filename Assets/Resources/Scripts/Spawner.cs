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

    public CombatManager combat;
    public abilitySelector ability;
    public deathBarrier death;
    public WeaponSpawner weapon;

    public GameObject panelInicio;

    public Teleporter teleporter;

    public GameObject vida; // Prefab del HUD de vida
    public Transform vidaT; // Posición donde se colocará el HUD de vida

    private PhotonView photonView;
    private PlayerBlink player1;
    private playerBlink2 player2;

    public float sharedLife = 10f; // Vida compartida entre ambos jugadores

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (PhotonNetwork.PlayerList.Length == 1)
        {
            // Instanciar el jugador 1 en la posición de ninja1
            GameObject player1Obj = PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);
            player1 = player1Obj.GetComponent<PlayerBlink>();

            // Instanciar la barra de vida y sincronizarla
            InstanciarVida();
        }
        else if (PhotonNetwork.PlayerList.Length > 1)
        {
            // Instanciar los jugadores en las posiciones correspondientes
            GameObject player2Obj = PhotonNetwork.Instantiate(playerPrefab2.name, ninja2.position, ninja2.rotation);
            player2 = player2Obj.GetComponent<playerBlink2>();

            GameObject player1Obj = PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);
            player1 = player1Obj.GetComponent<PlayerBlink>();

            // Instanciar la barra de vida y sincronizarla
            InstanciarVida();
        }
        else if (PhotonNetwork.PlayerList.Length == 0)
        {
            // Mostrar el panel de inicio si no hay jugadores conectados
            panelInicio.SetActive(true);
        }
    }

    void Update()
    {
        kita = GameObject.FindWithTag("player2");
        if (kita != null)
        {
            weapon.enabled = true;
            death.enabled = true;
            ability.enabled = true;
            combat.enabled = true;
            teleporter.enabled = false;
        }
    }

    // Método para instanciar el HUD de vida y sincronizar su estado
    void InstanciarVida()
    {
        // Instanciar el HUD de vida en la posición adecuada en la UI
        GameObject vidaInstanciada = PhotonNetwork.Instantiate(vida.name, vidaT.position, vidaT.rotation);
        vidaInstanciada.transform.SetParent(GameObject.Find("Game UI").transform, false);
    }

    // Método llamado para reducir la vida de manera sincronizada
    [PunRPC]
    public void ReducirVida(float cantidad)
    {
        // Solo el jugador que tenga autoridad sobre este objeto puede reducir la vida
        if (photonView.IsMine)
        {
            sharedLife -= cantidad;

            // Actualizamos la vida en ambos jugadores
            player1.health = sharedLife;
            player2.health = sharedLife;

            player1.UpdateHealthBar(); // Método para actualizar la barra de vida
            player2.UpdateHealthBar(); // Método para actualizar la barra de vida

            if (sharedLife <= 0)
            {
                // Aquí puedes manejar lo que ocurre cuando la vida llega a 0 (muerte, reinicio, etc.)
                Volver();
            }

            // Llama al RPC para actualizar la vida en todos los clientes
            photonView.RPC("ActualizarVida", RpcTarget.All, sharedLife);
        }
    }

    // Actualizar la barra de vida visualmente para todos los jugadores
    [PunRPC]
    public void ActualizarVida(float nuevaVida)
    {
        // Actualiza la barra de vida de ambos jugadores
        player1.health = nuevaVida;
        player2.health = nuevaVida;

        player1.UpdateHealthBar();
        player2.UpdateHealthBar();
    }

    public void Volver()
    {
        SceneManager.LoadScene("INICIO");
    }
}
