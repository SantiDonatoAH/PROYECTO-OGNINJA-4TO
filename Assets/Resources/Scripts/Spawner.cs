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



    private PhotonView photonView;


    public float sharedLife = 10f; // Vida compartida entre ambos jugadores

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (PhotonNetwork.PlayerList.Length == 1)
        {
            // Instanciar el jugador 1 en la posición de ninja1

            GameObject player1Obj = PhotonNetwork.Instantiate(playerPrefab.name, ninja1.position, ninja1.rotation);

            // Instanciar la barra de vida y sincronizarla
        }
        else if (PhotonNetwork.PlayerList.Length > 1)
        {
            // Instanciar los jugadores en las posiciones correspondientes
            GameObject player2Obj = PhotonNetwork.Instantiate(playerPrefab2.name, ninja2.position, ninja2.rotation);



            // Instanciar la barra de vida y sincronizarla
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


    // Método llamado para reducir la vida de manera sincronizada


    // Actualizar la barra de vida visualmente para todos los jugadores


    public void Volver()
    {
        SceneManager.LoadScene("INICIO");
    }
}