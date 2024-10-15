using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class vidadeleter : MonoBehaviourPunCallbacks
{
    // is called before the first frame update
    [PunRPC]
    void Start()
    {
        GameObject gameUI = GameObject.Find("Game UI");

        // Verificar si el objeto es hijo de "Game UI"
        if (gameObject.transform.parent != gameUI.transform)
        {
            // Si no es hijo, destruir el objeto
            Destroy(gameObject);
            PhotonNetwork.Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
