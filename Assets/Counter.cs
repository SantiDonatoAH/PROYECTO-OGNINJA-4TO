using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text pts2;
    public Text pts1;

    public static Counter instance;
    // Start is called before the first frame update
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // No destruir al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject);  // Destruir esta instancia si ya existe otra
            return;  // Salir del Awake para evitar ejecutar el código en la instancia destruida
        }
    }

    // Update is called once per frame
    void Update()
    {
       


      
    }

    public void WIN1()
    {
        int number = int.Parse(pts1.text);
        number++;
        pts1.text = number.ToString();
        Debug.Log("1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WIN2() 
    {
        int number = int.Parse(pts2.text);
        number++;
        pts2.text = number.ToString();
        Debug.Log("2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
