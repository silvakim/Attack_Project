using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.IO;

public class OnlineUIManager : MonoBehaviourPunCallbacks
{

  // public InputField NickNameInput;

    

    public override void OnDisconnected(DisconnectCause cause)
    {

        //connectionInfoText.text = "서버와 연결에 실패했습니다";
        Debug.Log("ConnectingFailed");
    }


    public void Connect()
    {
        //NickNameInput.text = PhotonNetwork.NickName;

        if (PhotonNetwork.IsConnected)
            //if (NickNameInput.text != "")
            {

                //connectionInfoText.text = "연결중입니다";
                PhotonNetwork.JoinRandomRoom();
                Debug.Log("RoomConnecting");

            }
           // else if (NickNameInput.text != "")
            {
                //connectionInfoText.text = "재연결중입니다";

                PhotonNetwork.ConnectUsingSettings();
                Debug.Log("RoomReconnecting");
            }
           // else
            {
              //  NickNameInput.GetComponent<Animator>().SetTrigger("on");
            }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //connectionInfoText.text = "방을 생성합니다";
        PhotonNetwork.CreateRoom(roomName: null, new RoomOptions { MaxPlayers = 7 });
        Debug.Log("CreatingRoom");
    }

    public override void OnJoinedRoom()
    {
        //connectionInfoText.text = "방에 입장합니다";
        Debug.Log("방입장");
        PhotonNetwork.LoadLevel("GameRoomScenes");
    }
}
