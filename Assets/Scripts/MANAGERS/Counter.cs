using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text pts2;
    public Text pts1;
    public int Rondas = 3;
    public GameObject PanelVictoria;
    public GameObject Texto1;
    public GameObject Texto2;

    // Variables estáticas para mantener los valores
    private static int score1 = 0;
    private static int score2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Restaurar los valores después de que la escena se recargue
        pts1.text = score1.ToString();
        pts2.text = score2.ToString();

        PanelVictoria.SetActive(false);
        Texto1.SetActive(false);
        Texto2.SetActive(false);
    }

    public void WIN1()
    {
        // Incrementar el valor y almacenarlo
        score1++;
        pts1.text = score1.ToString();
        Debug.Log("1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (score1 == Rondas)
        {
            PanelVictoria.SetActive(true);
            Texto1.SetActive(true);
        }
    }

    public void WIN2()
    {
        // Incrementar el valor y almacenarlo
        score2++;
        pts2.text = score2.ToString();
        Debug.Log("2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (score2 == Rondas)
        {
            PanelVictoria.SetActive(true);
            Texto2.SetActive(true);
        }

    }
}