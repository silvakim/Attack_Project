using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class PlayerInfo : Photon.Pun.MonoBehaviourPun, IPunObservable
{
    public Text _playerName;
    public int colorIndex;
    public SpriteRenderer[] playerBody;

    public List<Color> _allPlayerColors = new List<Color>();

   



    public Color CurrentColor
    {
        get { return _allPlayerColors[colorIndex]; }
    }

    private void Awake()
    {
        if (photonView.IsMine)
        {
            colorIndex = Random.Range(0, _allPlayerColors.Count);
            _playerName.text = PhotonNetwork.LocalPlayer.NickName;
            
        }
        else
        {
            //_playerName.text = GetPlayerName(PhotonView.OwnerActorNr);
        }
       
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Owner.
            stream.SendNext(colorIndex);
           
        }
        else
        {
            // Remote.
            colorIndex = (int)stream.ReceiveNext();
           
        }
    }

    private void Update()
    {
        foreach (SpriteRenderer playerPart in playerBody)
        {
            playerPart.color = _allPlayerColors[colorIndex];
        }

      
    }
    private string GetPlayerName(int actorID)
    {
        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value.ActorNumber == actorID)
            {
                return player.Value.NickName;
            }
        }

        return "[none]";
    }


}