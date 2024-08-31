using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SettingsConfig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OnclickSettings();
        }
        Time.timeScale = 1;
    }

    public void OnclickSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
