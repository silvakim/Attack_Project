using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


/// <summary>
/// ���θ޴��� git�������� �ּ� �Ϸ�.
/// 
/// </summary>
public class MainMenuUI : MonoBehaviourPunCallbacks  //onClickOnlineButton�Լ��� �����
{

   
    public void OnclickQuitButton() //�����Ϳ��� ����� ���¶�� �÷��̸� �ߴܽ�Ű��
    {   //����� ���¶�� ���ø����̼��� �����ϵ���.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
