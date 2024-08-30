using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour


{ 
    public GameObject secondPanel;
    public GameObject panelhabilidad;
    public GameObject PanelSettings;
    public GameObject Panel2;
    public GameObject PanelGame;

    public Text vidaText;
    public Text RoundText;
    

    // Start is called before the first frame update
    void Start()
    {
        secondPanel.SetActive(false);
        PanelSettings.SetActive(false);
        PanelGame.SetActive(false);
        Panel2.SetActive(false);
        panelhabilidad.SetActive(false);
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
        panelhabilidad.SetActive(false);

    }
    public void OnClickHab()
    {
        Panel2.SetActive(false);
        PanelGame.SetActive(false);
        panelhabilidad.SetActive(true);
    }

    public void OnBack()
    {
        PanelSettings.SetActive(false);
        Panel2.SetActive(false);
        secondPanel.SetActive(true);
        panelhabilidad.SetActive(false);

    }

    public void OnButton2()
    {
        Panel2.SetActive(true);
        PanelGame.SetActive(false);
        panelhabilidad.SetActive(true);

    }
    public void OnButtonGame()
    {
        Panel2.SetActive(false);
        PanelGame.SetActive(true);
        panelhabilidad.SetActive(true);

    }
    public void OnClickMenosVida()
    {
        int VidaActual = int.Parse(vidaText.text);
        VidaActual -= 10;
        if (VidaActual <= 9)
        {
            VidaActual = 100;
        }
        vidaText.text = VidaActual.ToString();
    }

    public void OnClickMasVida()
    {
        int VidaActual2 = int.Parse(vidaText.text);
        VidaActual2 += 10;
        if (VidaActual2 >= 201)
        {
            VidaActual2 = 100;
        }
        vidaText.text = VidaActual2.ToString();
    }

    public void OnClickMenosRounds()
    {
        int RoundActual = int.Parse(RoundText.text);
        RoundActual -= 1;
        if (RoundActual <= 0)
        {
            RoundActual = 3;
        }
        RoundText.text = RoundActual.ToString();
    }

    public void OnClickMasRounds()
    {
        int RoundActual2 = int.Parse(RoundText.text);
        RoundActual2 += 1;
        if (RoundActual2 >= 11)
        {
            RoundActual2 = 3;
        }
        RoundText.text = RoundActual2.ToString();
    }
}
