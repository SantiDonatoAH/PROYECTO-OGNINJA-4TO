using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject secondPanel;
    public GameObject PanelSettings;
    public GameObject Panel2;
    public GameObject PanelGame;

    // Start is called before the first frame update
    void Start()
    {
        secondPanel.SetActive(false);
        PanelSettings.SetActive(false);
        PanelGame.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnclickStart()
    {
        secondPanel.SetActive(true);
    }

    public void OnClickSettings()
    {
        PanelSettings.SetActive(true);
        secondPanel.SetActive(false);
        PanelGame.SetActive(true);

    }

    public void OnBack()
    {
        PanelSettings.SetActive(false);
        Panel2.SetActive(false);
        secondPanel.SetActive(true);
    }

    public void OnButton2()
    {
        Panel2.SetActive(true);
        PanelGame.SetActive(false);
    }
    public void OnButtonGame()
    {
        Panel2.SetActive(false);
        PanelGame.SetActive(true);
    }
}
