using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class CameraSetup : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {   //내가 로컬 플레이어면
        if (this.photonView.IsMine)
        {   //씬에 있는 시네머신 가상카메라를 찾는다
            var followCam = FindObjectOfType<CinemachineVirtualCamera>();
            //가상카메라의 추적대상을 나(GameObject)로 맞춘다
            followCam.Follow = this.transform;
            followCam.LookAt = this.transform;
        }
    }

   
}
