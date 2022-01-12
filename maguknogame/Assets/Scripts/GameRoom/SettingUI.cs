using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SettingUI : MonoBehaviourPunCallbacks
{
    public void LeaveRoom()
    {

        PhotonNetwork.LeaveRoom();
       
    }
    public override void OnLeftRoom()
    {
        if (SceneManager.GetActiveScene().name == "GameRoomScenes")
        {
            SceneManager.LoadScene("MainMenuScenes");
            return;
            Debug.Log("leaveRoom");
        }

    }
   
}
