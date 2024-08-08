using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonPausePanel()
    {
        PausePanel();
    }

    private void PausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinuePanel ()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
