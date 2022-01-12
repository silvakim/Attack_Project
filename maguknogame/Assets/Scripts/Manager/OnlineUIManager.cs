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

        //connectionInfoText.text = "������ ���ῡ �����߽��ϴ�";
        Debug.Log("ConnectingFailed");
    }


    public void Connect()
    {
        //NickNameInput.text = PhotonNetwork.NickName;

        if (PhotonNetwork.IsConnected)
            //if (NickNameInput.text != "")
            {

                //connectionInfoText.text = "�������Դϴ�";
                PhotonNetwork.JoinRandomRoom();
                Debug.Log("RoomConnecting");

            }
           // else if (NickNameInput.text != "")
            {
                //connectionInfoText.text = "�翬�����Դϴ�";

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
        //connectionInfoText.text = "���� �����մϴ�";
        PhotonNetwork.CreateRoom(roomName: null, new RoomOptions { MaxPlayers = 7 });
        Debug.Log("CreatingRoom");
    }

    public override void OnJoinedRoom()
    {
        //connectionInfoText.text = "�濡 �����մϴ�";
        Debug.Log("������");
        PhotonNetwork.LoadLevel("GameRoomScenes");
    }
}
