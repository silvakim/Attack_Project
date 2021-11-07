using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //게임종료버튼 눌렀을때 호출
    public void ClickQuit()
    {
        //유니티에디터
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        //안드로이드
#else
Application.Quit{};
#endif
    }
}
