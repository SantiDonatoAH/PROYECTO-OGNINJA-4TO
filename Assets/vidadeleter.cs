using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class vidadeleter : MonoBehaviourPunCallbacks
{
    public GameObject im1;
    public GameObject im2;

    public Image image1;
    public Image image2;
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

    [PunRPC]
    public void Vida1(string hab)
    {
        im1 = GameObject.FindGameObjectWithTag("hab1");
        image1 = im1.GetComponent<Image>();

        image1.sprite = Resources.Load<Sprite>(hab); // Carga la imagen correspondiente a "cooldown"
    }

    [PunRPC]
    public void Vida2(string hab)
    {
        im2 = GameObject.FindGameObjectWithTag("hab2");

        image2 = im2.GetComponent<Image>();
        image2.sprite = Resources.Load<Sprite>(hab);
    }
}
