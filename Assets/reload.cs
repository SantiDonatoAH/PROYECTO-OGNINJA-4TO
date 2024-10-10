using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviourPunCallbacks
{
    public static reload instance;
    public GameObject kita;
    bool ranzo = true;

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

    [PunRPC]
    private void Update()
    {

        if (ranzo == true )
        {
            ranzo = false;
            PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    
}
