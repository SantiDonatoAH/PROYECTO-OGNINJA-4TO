using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ScreenController : MonoBehaviourPunCallbacks
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject GAME_UI;
    public Button pauseButton;
    public bool ispaused = false;


    public GameObject image1;
    public GameObject image2;

    void Start()
    {
        ispaused = false;
        pausePanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                ContinuePanel();  // Cierra el panel si está abierto
                if (PhotonNetwork.IsConnected)
                {
                    photonView.RPC("Play", RpcTarget.All); // Llamada RPC para sincronizar el daño entre todas las sesiones
                }
            }
            else
            {
                PausePanel();
                if (PhotonNetwork.IsConnected)
                {
                    photonView.RPC("Reseteo", RpcTarget.All); // Llamada RPC para sincronizar el daño entre todas las sesiones
                }

            }
            
        }
    }

    public void PausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        ispaused = true;
        image1.SetActive(false);
        image2.SetActive(false);

    }

    public void ContinuePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        ispaused = false;
        settingsPanel.SetActive(false);
        image1.SetActive(true);
        image2.SetActive(true);
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1;
        ispaused = false;
        SceneManager.LoadScene("Lobby");
        settingsPanel.SetActive(false);
        pausePanel.SetActive(false);
        Destroy(this.GAME_UI);   
    }

    public void OnSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void OnCloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    [PunRPC]
    public void Reseteo()
    {
        Time.timeScale = 0;
    }

    [PunRPC]
    public void Play()
    {
        Time.timeScale = 1;
    }
}
