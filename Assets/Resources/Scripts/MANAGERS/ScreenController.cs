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

    public Text pts1;
    public Text pts2;

    public CounterOff coff;

    public GameObject help;
    public bool Ishelp = false;
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
            Ishelp = false;
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
        if (Ishelp == false) { help.SetActive(false); }
    }

    public void PausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        ispaused = true;
       

    }

    public void ContinuePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        ispaused = false;
        settingsPanel.SetActive(false);
       
    }

    public void OnMainMenu()
    {
       CounterOff.score1 = 0;
        CounterOff.score2 = 0;

        pts1.text = 0.ToString();
        pts2.text = 0.ToString();

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
        Ishelp = false;

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

    public void OnHelp()
    {
        help.SetActive(true) ;
        Ishelp = true;
    }
}
