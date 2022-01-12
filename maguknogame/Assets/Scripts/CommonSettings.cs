using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EControlType
{
    Mouse,// 터치 패드로 바꿀것.! 2021년 10월_4일
    KeyboardMouse
}

public class CommonSettings
{
    public static EControlType controlType;

    public static string nickname;

}
