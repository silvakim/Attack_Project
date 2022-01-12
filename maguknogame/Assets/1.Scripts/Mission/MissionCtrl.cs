using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCtrl : MonoBehaviour
{
    public Slider guage;
    int missionCount;
   

    //미션성공하면 호출
    public void MissionSuccess()
    {
        
        missionCount++;

        guage.value = missionCount / 9f;


        
    }
    
}
