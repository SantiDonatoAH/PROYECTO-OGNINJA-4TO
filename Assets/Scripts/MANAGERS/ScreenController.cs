using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    

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
    }

    public void ContinuePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
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
