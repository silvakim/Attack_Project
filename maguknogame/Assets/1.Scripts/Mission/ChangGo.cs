using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangGo : MonoBehaviour
{
    public Transform handle, rotate;
    Animator anim;
    PlayerCtrl playerCtrl_script;
    RectTransform rect_handle;



    bool isDrag;
     
   
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rect_handle = handle.GetComponent<RectTransform>();

    }
    public void Update()
    {
       

        //�巡��
        if (isDrag)
        {
            handle.position = Input.mousePosition;
            rect_handle.anchoredPosition = new Vector2(184, Mathf.Clamp(rect_handle.anchoredPosition.y, -222, 222));

            //�巡�� ����
            if (Input.GetMouseButtonUp(0))
            {
                //�������� üũ
                if(rect_handle.anchoredPosition.y > -3 && rect_handle.anchoredPosition.y < 3)
                {
                    Invoke("MissionSuccess", 2);
                }
                isDrag = false;

                

            }
        }
        rotate.eulerAngles = new Vector3(0, 0, 90*rect_handle.anchoredPosition.y /222);

        //������
      
        if (rect_handle.anchoredPosition.y > -3 && rect_handle.anchoredPosition.y < 3)
        {
            Invoke("MissionSuccess", 2);
        }
        
    }


    //�̼ǽ���
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();
        



    }
    //������ư ������ ȣ��
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    //�ڵ� ������ ȣ��
    public void ClickHandle()
    {
        isDrag = true;
    }
    
    
    //�̼Ǽ����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
