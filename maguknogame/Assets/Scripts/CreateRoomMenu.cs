using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    public void OnClick_CreateRoom()
    {
      if (!PhotonNetwork.IsConnected)
      return;


        RoomOptions options = new RoomOptions();
      options.MaxPlayers = 7;
      PhotonNetwork.JoinRandomOrCreateRoom(null, options.MaxPlayers = 7);
        //PhotonNetwork.CreateRoom(roomName: null, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        
    }
}
