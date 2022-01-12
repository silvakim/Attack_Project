using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System.Text;





public class ForUsRoomManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1";

    public Text connectionInfoText;

    public Button StartButton; // 룸 접속 버튼
   


    [SerializeField] private InputField _roomPasswordInput;
   
    [SerializeField] private PlayerItemUI _playerItemUIPrefab;
    [SerializeField] private Transform _playerListParent;

    [SerializeField] private InputField _privateRoomPassword;
    [SerializeField] private GameObject _privateRoomPasswordWindow;
    private string _currentPrivateRoomPassword;

    [SerializeField] private InputField _playerNameInput;
    [SerializeField] private Text _playerNameLabel;
    private bool _isPlayerNameChanging;


    private List<PlayerItemUI> _playerList = new List<PlayerItemUI>();


    public InputField NickNameInput;




    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;


        connectionInfoText.text = "서버와 연결중입니다";
        Debug.Log("ServerConnecting");
        this.StartButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {

        connectionInfoText.text = "서버와 연결되었습니다";
        Debug.Log("ServerConnected");
        this.StartButton.interactable = true;
        PhotonNetwork.NickName = "Player" + Random.Range(0, 500);
        _playerNameLabel.text = PhotonNetwork.NickName;
        NickNameInput.text = PhotonNetwork.NickName;
        PhotonNetwork.JoinLobby();

    }

    public override void OnDisconnected(DisconnectCause cause)
    {

        //connectionInfoText.text = "서버와 연결에 실패했습니다";
        Debug.Log("ConnectingFailed");
        PhotonNetwork.ConnectUsingSettings();
    }


    public void Connect()
    {
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
       
        if (PhotonNetwork.IsConnected)
            if (NickNameInput.text != "")
            {

                //connectionInfoText.text = "연결중입니다";
                PhotonNetwork.JoinRandomRoom();
                Debug.Log("RoomConnecting");

            }
            else if (NickNameInput.text != "")
            {
                //connectionInfoText.text = "재연결중입니다";

                PhotonNetwork.ConnectUsingSettings();
                Debug.Log("RoomReconnecting");
            }
            //else
            //{
                //NickNameInput.GetComponent<Animator>().SetTrigger("on");
            //}
    }

    public void JoinPrivateRoom(string password)
    {
       
        _currentPrivateRoomPassword = password;
        _privateRoomPassword.text = string.Empty;
        _privateRoomPasswordWindow.SetActive(true);
        Debug.Log("JoinPrivateRoom");

    }

    public void CreatePrivateRoom()
    {
        
        RoomOptions roomOpts = new RoomOptions();

        roomOpts.MaxPlayers = 7;
        roomOpts.CustomRoomPropertiesForLobby = new string[] { "pwd" };
        roomOpts.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();
        roomOpts.CustomRoomProperties["pwd"] = CreateMD5(_roomPasswordInput.text);

        PhotonNetwork.CreateRoom("",roomOpts, null);
        Debug.Log("CreatingPrivateRoom");

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //connectionInfoText.text = "방을 생성합니다";
        PhotonNetwork.CreateRoom(roomName: null, new RoomOptions { MaxPlayers = 7 });
        Debug.Log("CreatingRoom");
        UpdatePlayerList();
    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방에 입장합니다";
        Debug.Log("방입장");
        PhotonNetwork.LoadLevel("GameRoomScenes");
        UpdatePlayerList();



       

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }
    private void UpdatePlayerList()
    {
        //Clear thr current player list
        for (int i = 0; i < _playerList.Count; i++)
        {
            Destroy(_playerList[i].gameObject);
        }
        _playerList.Clear();

        if (PhotonNetwork.CurrentRoom == null) { return; }

        // Generate a new list of players
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItemUI newPlayerItem = Instantiate(_playerItemUIPrefab);

            newPlayerItem.transform.SetParent(_playerListParent);
            //newPlayerItem.SetName(player.Value.NickName);

            _playerList.Add(newPlayerItem);
        }
        
    }

    public void OnChangePlayerNamePressed()
    {
        if(_isPlayerNameChanging == false)
        {
            _playerNameInput.text = _playerNameLabel.text;
            _playerNameLabel.gameObject.SetActive(false);
            _playerNameInput.gameObject.SetActive(true);
            _isPlayerNameChanging = true;
        }
        else
        {
            // check for empty or long names
            if (string.IsNullOrEmpty(_playerNameInput.text) == false && _playerNameInput.text.Length <= 12)
            {
                _playerNameLabel.text = _playerNameInput.text;
                PhotonNetwork.LocalPlayer.NickName = _playerNameInput.text;
                photonView.RPC("ForcePlayerListUpdate", RpcTarget.All);
            }

            _playerNameLabel.gameObject.SetActive(true);
            _playerNameInput.gameObject.SetActive(false);
            _isPlayerNameChanging = false;
        }
    }

    [PunRPC]
    public void ForcePlayerListUpdate()
    {
        UpdatePlayerList();
    }

    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

}

  

   

    

  