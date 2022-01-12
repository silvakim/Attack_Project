using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class MyPhotonCharacter : MonoBehaviour
{
    PhotonView myPV;
    GameObject myPlayerAvatar;

    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
        if (myPV.IsMine)
        {
            myPlayerAvatar = PhotonNetwork.Instantiate(Path.Combine("Character"), Vector3.zero, Quaternion.identity);
        }
        
    }

    
}
