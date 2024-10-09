using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviourPunCallbacks
{
    public static reload instance;
    public GameObject kita;

    private void Awake()
    {
        // Implementar el patrón Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Destruir esta instancia si ya existe otra
        }
        else
        {
            instance = this;
        }
    }

    [PunRPC]
    private void Update()
    {
        kita = GameObject.FindWithTag("player2");

        if (kita != null )
        {
            PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void OnEnable()
    {
        // Suscribirse al evento de recarga de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Cancelar la suscripción al evento de recarga de escena
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Destruir todos los objetos al recargar la escena
        Destroy(gameObject);
    }

    
}
