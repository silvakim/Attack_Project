using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCtrl : MonoBehaviour
{
    public Slider guage;
    int missionCount;
   

    //�̼Ǽ����ϸ� ȣ��
    public void MissionSuccess()
    {
        
        missionCount++;

        guage.value = missionCount / 9f;


        
    }
    
}
