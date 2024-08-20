using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Button pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            OnclickStart();
        }
       Time.timeScale = 1;

    }

    public void OnclickStart()
    {
        SceneManager.LoadScene("PRINCIPALscene");
    }
}
