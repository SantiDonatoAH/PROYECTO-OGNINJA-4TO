using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombucha100 : MonoBehaviourPunCallbacks
{
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void Mover()
    {
        view.RPC("SyncWeaponPickup", RpcTarget.AllBuffered);


    }

    public void SyncWeaponPickup()
    {
        transform.position = new Vector2(100, 0);
    }
}
