using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            OnclickGoBack();
        }
        Time.timeScale = 1;
    }

    public void OnclickGoBack()
    {
        SceneManager.LoadScene("INICIO");
    }
}
