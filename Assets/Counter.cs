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
    void start()
    {
        
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
