using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  3가지 종류로 나눠야함 - 
/// </summary>

public class RoomConditionUI : MonoBehaviour
{//이미지 변수List선언
    [SerializeField]
    private List<Image> kingImgs;

    [SerializeField]
    private List<Image> crewImgs;
    
    [SerializeField]
    private List<Button> imposterCountButtons;
    
    [SerializeField]
    private List<Button> maxPlayerCountButtons;

    private CreateGameRoomData roomData; //나중에 참조할 멤버변수

    void Start()  // 
    {
        for (int i = 0; i < crewImgs.Count; i++)
        {
            Material materialTnstance = Instantiate(crewImgs[i].material);
            crewImgs[i].material = materialTnstance;
        }

        // 룸데이터 의 값에 (왕1 간신1 맥스6) 하고 UpdateCrewImages함수 실행
        roomData = new CreateGameRoomData() { kingCount = 1, imposterCount = 1, maxPlayerCount = 10 };
        UpdateCrewImages();
    }

    //임포스터와 플레이어 수에 따라 바뀌는 함수
    //수가 0이 될때까지 플레이어를 뽑아 RED로 만들어줌.   -- 임포스터 수 표현

    private void UpdateCrewImages()
    {
        int imposterCount = roomData.imposterCount;
        int idx = 0;
        while (imposterCount != 0)
        {
            if (idx >= roomData.maxPlayerCount)                      
            {
                idx = 0;
         
            // Debug.Log("About to set the color", gameObject);

            if (crewImgs[idx].material.GetColor("_PlayerColor") != Color.red && Random.Range(0, 5) == 0)
            {
                crewImgs[idx].material.SetColor("_PlayerColor", Color.red);
                imposterCount--;
            }
            idx++;
        }

        //설정한 크루원들만 이미지 활성, 나머지는 비활성
        for (int i = 0; i < crewImgs.Count; i++)  
        {
            if (i < roomData.maxPlayerCount)
            {
                crewImgs[i].gameObject.SetActive(true);
            }
            else
            {
                crewImgs[i].gameObject.SetActive(false);
            }
        }
    }
}

    //새로 만드는 방의 데이터를 저장. 방생성이 완료될때, 새로만들어지는 방에 전달하는 클래스다.
    public class CreateGameRoomData
    {
        public int kingCount;
        public int imposterCount;
        public int maxPlayerCount;
    }
}

//    void Start()
//    {

//        //
//        //    for (int i = 0; i < crewImgs.Count; i++)
//        //    {
//        //        Material materialTnstance = Instantiate(crewImgs[i].material);
//        //        crewImgs[i].material = materialTnstance;
//        //    }

//        // 룸데이터 의 값에 (왕1 간신1 맥스6) 하고 UpdateCrewImages함수 실행
//        roomData = new CreateGameRoomData() { kingCount = 1, imposterCount = 1, maxPlayerCount = 10 };
//        UpdateCrewImages();
//    }

//    private void UpdateCrewImages()  //임포스터와 플레이어 수에 따라 바뀌는 함수 
//    { //수가 0이 될때까지 플레이어를 뽑아 RED로 만들어줌.   -- 임포스터 수 표현
//        int imposterCount = roomData.imposterCount;
//        int idx = 0;
//        while (imposterCount != 0)
//        {
//            if (idx >= roomData.maxPlayerCount)
//            {
//                idx = 0;
//            }

//            // Debug.Log("About to set the color", gameObject);

//            if (crewImgs[idx].material.GetColor("_PlayerColor") != Color.red && Random.Range(0, 6) == 0)
//            {
//                crewImgs[idx].material.SetColor("_PlayerColor", Color.red);
//                imposterCount--;
//            }
//            idx++;
//        }

//        for (int i = 0; i < crewImgs.Count; i++)  //설정한 크루원들만 이미지 활성, 나머지는 비활성
//        {
//            if (i < roomData.maxPlayerCount)
//            {
//                crewImgs[i].gameObject.SetActive(true);
//            }
//            else
//            {
//                crewImgs[i].gameObject.SetActive(false);
//            }
//        }
//    }
//}

//public class CreateGameRoomData
//{
//    public int kingCount;
//    public int imposterCount;
//    public int maxPlayerCount;

//}