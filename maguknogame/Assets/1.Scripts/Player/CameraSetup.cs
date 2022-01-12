using Cinemachine;
using Photon.Pun;
using UnityEngine;

public class CameraSetup : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {   //���� ���� �÷��̾��
        if (this.photonView.IsMine)
        {   //���� �ִ� �ó׸ӽ� ����ī�޶� ã�´�
            var followCam = FindObjectOfType<CinemachineVirtualCamera>();
            //����ī�޶��� ��������� ��(GameObject)�� �����
            followCam.Follow = this.transform;
            followCam.LookAt = this.transform;
        }
    }

   
}
