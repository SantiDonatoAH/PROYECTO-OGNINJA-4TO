using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class Counter : MonoBehaviourPunCallbacks
{
    public CombatManager combatManagerOff;

    public GameObject[] ninja1;
    public GameObject[] ninja2;
    public GameObject[] armas;

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
        ninja1 = GameObject.FindGameObjectsWithTag("player1");
        ninja2 = GameObject.FindGameObjectsWithTag("player2");
        armas = GameObject.FindGameObjectsWithTag("Weapon");


        pts1.text = score1.ToString();
        pts2.text = score2.ToString();

        PanelVictoria.SetActive(false);
        Texto1.SetActive(false);
        Texto2.SetActive(false);
    }

    public void WIN1()
    {
       // OnBorrar();


        // Incrementar el valor y almacenarlo
        score1++;
        pts1.text = score1.ToString();
        Debug.Log("1");
        if (score1 == Rondas)
        {
            combatManagerOff.enabled = false;
            Time.timeScale = 0;
            PanelVictoria.SetActive(true);
            Texto1.SetActive(true);
        }
        else
        {
            PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }

       
    }

    public void WIN2()
    {
      //OnBorrar();

        // Incrementar el valor y almacenarlo
        score2++;
        pts2.text = score2.ToString();
        Debug.Log("2");

        if (score2 == Rondas)
        {
            combatManagerOff.enabled = false;
            Time.timeScale = 0;
            PanelVictoria.SetActive(true);
            Texto2.SetActive(true);
        }
        else
        {
            PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
    [PunRPC]
    public void OnBorrar()
    {
        foreach (GameObject obj in armas)
        {
            Destroy(obj);
            PhotonNetwork.Destroy(obj);
        }
        foreach (GameObject obj in ninja1)
        {
            PhotonNetwork.Destroy(obj);
            Destroy(obj);
        }

        foreach (GameObject obj in ninja2)
        {
            PhotonNetwork.Destroy(obj);
            Destroy(obj);
        }

       
    }
    [PunRPC]
    public void OnReplay()
    {
        score1 = 0;
        score2 = 0;

        pts1.text = score1.ToString();
        pts2.text = score2.ToString();

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}