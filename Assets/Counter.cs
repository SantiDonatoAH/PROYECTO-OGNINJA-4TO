using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text pts2;
    public Text pts1;

    // Variables estáticas para mantener los valores
    private static int score1 = 0;
    private static int score2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Restaurar los valores después de que la escena se recargue
        pts1.text = score1.ToString();
        pts2.text = score2.ToString();
    }

    public void WIN1()
    {
        // Incrementar el valor y almacenarlo
        score1++;
        pts1.text = score1.ToString();
        Debug.Log("1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WIN2()
    {
        // Incrementar el valor y almacenarlo
        score2++;
        pts2.text = score2.ToString();
        Debug.Log("2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
