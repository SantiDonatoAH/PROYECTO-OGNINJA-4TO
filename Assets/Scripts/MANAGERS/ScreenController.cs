using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public Button pauseButton;
    public bool ispaused = false;

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
            }
            else
            {
                PausePanel();  // Abre el panel si está cerrado
            }
        }
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
    }

    public void OnSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void OnCloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
