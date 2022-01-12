using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
//using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WaitingRoomManger : MonoBehaviourPunCallbacks
{
    public Text[] ChatText;
    public InputField ChatInput;

   


    public PhotonView PV;
    [SerializeField] private Button startButton;


    public override void OnJoinedRoom()
    {
        
         Debug.Log("방입장");
         PhotonNetwork.LoadLevel("GameRoomScenes");


        if (PhotonNetwork.IsMasterClient == true)
           
        {
            startButton.interactable = true;
        }
        if (PhotonNetwork.IsMasterClient == false)
        {
            startButton.interactable = false;
        }
        
    }

   
  
    public void GameStartButton()
    {
        Debug.Log("게임시작");
        PhotonNetwork.LoadLevel("GameStart_Scene");

        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
    }
    

    public void Send()
    {
        PV.RPC("ChatRPC", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName + " : " + ChatInput.text);
        ChatInput.text = "";
    }

    [PunRPC] // RPC는 플레이어가 속해있는 방 모든 인원에게 전달한다
    void ChatRPC(string msg)
    {
        bool isInput = false;
        for (int i = 0; i < ChatText.Length; i++)
            if (ChatText[i].text == "")
            {
                isInput = true;
                ChatText[i].text = msg;
                break;
            }
        if (!isInput) // 꽉차면 한칸씩 위로 올림
        {
            for (int i = 1; i < ChatText.Length; i++) ChatText[i - 1].text = ChatText[i].text;
            ChatText[ChatText.Length - 1].text = msg;
        }
    }
}
