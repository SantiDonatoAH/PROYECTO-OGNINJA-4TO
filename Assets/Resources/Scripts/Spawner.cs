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
    public WeaponSpawner weapon;
    public GameObject reload;

    public GameObject panelInicio;

    private PhotonView photonView;


    public float sharedLife = 10f; // Vida compartida entre ambos jugadores

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
        if (kita != null && kita2 !=null)
        {
            weapon.enabled = true;
            death.enabled = true;
            ability.enabled = true;
            combat.enabled = true;
            PhotonNetwork.Instantiate(reload.name, ninja2.position, ninja2.rotation);
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