using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class OnlineUI : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField nicknameInputField;

   
    //[Header("DisconnectPanel")]
    public InputField NickNameInput;


    public void GoToMainMenu()
    {
        //PhotonNetwork.LeaveRoom(true);
        SceneManager.LoadScene("MainMenuScenes");
        Debug.Log("GoToMainMenu");

        PhotonNetwork.ConnectUsingSettings();
        
    }


    //룸만드는 버튼 이름 입력하였는지, 확인하는 애니매이션 효과.
    public void OnClickCreateRoomButton()
    {
        if(NickNameInput.text != "")
        {
            NickNameInput.text = PhotonNetwork.NickName;
            CommonSettings.nickname = nicknameInputField.text;
            //createRoomUI.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            NickNameInput.GetComponent<Animator>().SetTrigger("on");
        }


    }
    public void OnClickEnterGameRoomButton()
    {
        if (NickNameInput.text != "")
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 7;
            PhotonNetwork.JoinRandomOrCreateRoom(null, options.MaxPlayers = 7);
            Debug.Log("CreatingRoom");
        }
        else
        {
            NickNameInput.GetComponent<Animator>().SetTrigger("on");
        }
    }
   

   
}