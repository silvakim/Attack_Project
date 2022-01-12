using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class CreateRoomUI : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private List<Image> crewImgs;


    [SerializeField]
    private List<Button> imposterCountButtons;

    [SerializeField]
    private List<Button> maxPlayerCountButtons;

    private CreateGameRoomData roomData;

    private int count;

    private void Start()
    {
        roomData = new CreateGameRoomData() { imposterCount = 1, maxPlayerCount = 6 };
        UpdateCrewImages();
        
    }

    public void UpdateImposterCount(int count)
    {
        roomData.imposterCount = count;
        for(int i = 0; i < imposterCountButtons.Count; i++)
        {
            if(i == count - 1)
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            
            else
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
        }

        int limitMaxPlayer = count == 1 ? 4 : count == 2 ? 6 : 7;
        if(roomData.maxPlayerCount < limitMaxPlayer)
        {
            UpdateMaxPlayerCount(limitMaxPlayer);
        }
        else
        {
            UpdateMaxPlayerCount(roomData.maxPlayerCount);
        }

        for(int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            var text = maxPlayerCountButtons[i].GetComponentInChildren<Text>();
            if(i < limitMaxPlayer - 4)
            {
                maxPlayerCountButtons[i].interactable = false;
                text.color = Color.gray;
            }
            else
            {
                maxPlayerCountButtons[i].interactable = true;
                text.color = Color.white;
            }
        }
    }

    public void UpdateMaxPlayerCount(int count)
    {
        roomData.maxPlayerCount = count;
        
        for(int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            if(i == count - 4)
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        UpdateCrewImages();
    }

    private void UpdateCrewImages()
    {
        int imposterCount = roomData.imposterCount;
        int idx = 0;
       
            if(idx >= roomData.maxPlayerCount)
            {
                idx = 0;
            }
            
            

        //if(crewImgs[idx].material.GetColor("_PlayerColor") != Color.black && Random.Range(0,5) == 0)
        //{
            //crewImgs[idx].material.SetColor("_PlayerColor", Color.black);
            //imposterCount--;
        //}
        idx++;
        

        for (int i = 0; i < crewImgs.Count; i++)
        {
            if(i < roomData.maxPlayerCount)
            {
                crewImgs[i].gameObject.SetActive(true);
            }
            else
            {
                crewImgs[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        Debug.Log("OnClick_CreateRoom() was called by PUN.");

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 7;
        PhotonNetwork.JoinOrCreateRoom(roomName:null, options, TypedLobby.Default);
    }
    //{  // ForUsRoomManager.singleton로 씬에 있는 network매니저를 가져와,
        //StartHost 함수 호출  == startHOST는 서버를 엶과 동시에
        //클라이언트로써 게임에 참가하게 만드는 함수
       

        //방 설정 작업 처리
        
    //}

    public class CreateGameRoomData
    {
        public int imposterCount;
        public int maxPlayerCount;
    }
}
