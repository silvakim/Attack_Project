using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  3���� ������ �������� - 
/// </summary>

public class RoomConditionUI : MonoBehaviour
{//�̹��� ����List����
    [SerializeField]
    private List<Image> kingImgs;

    [SerializeField]
    private List<Image> crewImgs;
    
    [SerializeField]
    private List<Button> imposterCountButtons;
    
    [SerializeField]
    private List<Button> maxPlayerCountButtons;

    private CreateGameRoomData roomData; //���߿� ������ �������

    void Start()  // 
    {
        for (int i = 0; i < crewImgs.Count; i++)
        {
            Material materialTnstance = Instantiate(crewImgs[i].material);
            crewImgs[i].material = materialTnstance;
        }

        // �뵥���� �� ���� (��1 ����1 �ƽ�6) �ϰ� UpdateCrewImages�Լ� ����
        roomData = new CreateGameRoomData() { kingCount = 1, imposterCount = 1, maxPlayerCount = 10 };
        UpdateCrewImages();
    }

    //�������Ϳ� �÷��̾� ���� ���� �ٲ�� �Լ�
    //���� 0�� �ɶ����� �÷��̾ �̾� RED�� �������.   -- �������� �� ǥ��

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

        //������ ũ����鸸 �̹��� Ȱ��, �������� ��Ȱ��
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

    //���� ����� ���� �����͸� ����. ������� �Ϸ�ɶ�, ���θ�������� �濡 �����ϴ� Ŭ������.
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

//        // �뵥���� �� ���� (��1 ����1 �ƽ�6) �ϰ� UpdateCrewImages�Լ� ����
//        roomData = new CreateGameRoomData() { kingCount = 1, imposterCount = 1, maxPlayerCount = 10 };
//        UpdateCrewImages();
//    }

//    private void UpdateCrewImages()  //�������Ϳ� �÷��̾� ���� ���� �ٲ�� �Լ� 
//    { //���� 0�� �ɶ����� �÷��̾ �̾� RED�� �������.   -- �������� �� ǥ��
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

//        for (int i = 0; i < crewImgs.Count; i++)  //������ ũ����鸸 �̹��� Ȱ��, �������� ��Ȱ��
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