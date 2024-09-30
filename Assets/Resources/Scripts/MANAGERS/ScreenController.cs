using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject GAME_UI;
    public Button pauseButton;
    public bool ispaused = false;

    public GameObject vida;

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
                vida.SetActive(true);
            }
            else
            {
                PausePanel();  // Abre el panel si está cerrado
                vida.SetActive(false);
            }
        }
    }

    public void PausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        ispaused = true;
        vida.SetActive(false);
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
        vida.SetActive(true);
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

    public void OnReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
