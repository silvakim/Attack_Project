using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


/// <summary>
/// 메인메뉴에 git시험으로 주석 완료.
/// 
/// </summary>
public class MainMenuUI : MonoBehaviourPunCallbacks  //onClickOnlineButton함수를 만들고
{

   
    public void OnclickQuitButton() //에디터에서 실행된 상태라면 플레이를 중단시키고
    {   //빌드된 상태라면 어플리케이션을 종료하도록.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
