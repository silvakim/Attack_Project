using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponRoom : MonoBehaviour
{


    public Transform Arrow;

    Animator anim;
    PlayerCtrl playerCtrl_script;
    RectTransform rect_Arrow;

    bool isDrag;
    Vector2 originPos;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rect_Arrow = Arrow.GetComponent<RectTransform>();
        Vector2 originPos = rect_Arrow.anchoredPosition;

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
    //ȭ��ǥ ������ ȣ��
    public void ClickArrow()
    {
        isDrag = true;

        //�巡��
        if (isDrag)
        {
            Arrow.position = Input.mousePosition;
            rect_Arrow.anchoredPosition = new Vector2(Mathf.Clamp(rect_Arrow.anchoredPosition.x, -4.2f, 190), originPos.y);

            //�巡�� ����
            if (Input.GetMouseButtonUp(0))
            {
                //rect_Arrow.anchoredPosition = originPos;
                isDrag = false;
            }
        }

        //�������� üũ
        if (rect_Arrow.anchoredPosition.x == 190)
        {
            Invoke("MissionSuccess", 0.5f);
        }
    }



    //�̼Ǽ����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
