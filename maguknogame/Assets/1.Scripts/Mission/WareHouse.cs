using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WareHouse : MonoBehaviour
{

    Animator anim;
    PlayerCtrl playerCtrl_script;

    Vector2 ClickPos;
    LineRenderer line;

    bool isDrag;
    float topX, bottomX;
   
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
    }
    public void Update()
    {
       

        //�巡��
        if (isDrag)
        {
            line.SetPosition(1, new Vector3(Input.mousePosition.x - ClickPos.x, Input.mousePosition.y - ClickPos.y, -10));

            //�巡�� ����
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                //�Ʒ� ���� ��Ҵٸ�
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject bottomLine = hit.transform.gameObject;

                    //�Ʒ� �� X��
                    bottomX = bottomLine.GetComponent<RectTransform>().anchoredPosition.x;

                    line.SetPosition(1, new Vector3(bottomX - topX, -500, -10));
                }
                //���� �ʾҴٸ�
                else
                {
                    line.SetPosition(1, new Vector3(0, 0, -10));
                }

                isDrag = false;
            }
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
    
    public void ClickLine(LineRenderer click)
    {
        ClickPos = Input.mousePosition;
        line = click;

        //���� �� y��
        topX = click.transform.parent.GetComponent<RectTransform>().anchoredPosition.x;


        isDrag = true;
    }
    //�̼Ǽ����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
