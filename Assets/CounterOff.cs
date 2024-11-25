using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CounterOff : MonoBehaviour
{
 public CombatManagerOff CombatManagerOff;

    public GameObject ninja1;
    public GameObject ninja2;

    public Text pts2;
    public Text pts1;
    public static int Rondas = 3;
    public GameObject PanelVictoria;
    public GameObject Texto1;
    public GameObject Texto2;

    public playerBlink2Off playerb2;
    public PlayerBlinkOff playerb;
    public abilitySelectorOff abilty;
    // Variables estáticas para mantener los valores
    public  static int score1 = 0;
    public static int score2 = 0;

    public static bool reactive = true;
    public RectTransform panelRectTransform;

    public Image im;
    void Start()
    {
        ninja1 = GameObject.FindGameObjectWithTag("player1");
        ninja2 = GameObject.FindGameObjectWithTag("player2");

        pts1.text = score1.ToString();
        pts2.text = score2.ToString();

        PanelVictoria.SetActive(false);
        Texto1.SetActive(false);
        Texto2.SetActive(false);

        if ((score1 != 0 || score2 != 0) || reactive == false)
        {
            Time.timeScale = 1;

            float panelWidth = panelRectTransform.rect.width;

            // Mueve el panel fuera de la pantalla hacia la izquierda
            panelRectTransform.anchoredPosition = new Vector2(-panelWidth, panelRectTransform.anchoredPosition.y);
            playerb.enabled = true;
            playerb2.enabled = true;
            abilty.enabled = true;
            abilty.Ninja1();
            abilty.Ninja2();
        }
    }

    public void WIN1()
    {


        score1++;
        pts1.text = score1.ToString();
        Debug.Log("1");

        if (score1 == Rondas)
        {
            CombatManagerOff.enabled = false;
            Time.timeScale = 0;
            PanelVictoria.SetActive(true);
            Texto1.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void WIN2()
    {

        score2++;
        pts2.text = score2.ToString();
        Debug.Log("2");

        if (score2 == Rondas)
        {
            CombatManagerOff.enabled = false;
            Time.timeScale = 0;
            PanelVictoria.SetActive(true);
            Texto2.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void OnReplay()
    {
        score1 = 0;
        score2 = 0;

        pts1.text = score1.ToString();
        pts2.text = score2.ToString();

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
    public void rondas(int cant)
    {
        Rondas = cant;
    }

    public void delete()
    {
        reactive = false;
        im.sprite = Resources.Load<Sprite>("no");

    }

    public void Change()
    {
        reactive = !reactive;
        if (reactive == true)
        {
            im.sprite = Resources.Load<Sprite>("si");
        }
        else
        {
            im.sprite = Resources.Load<Sprite>("no");
        }
    }
}