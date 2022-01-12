using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScholarRoom : MonoBehaviour
{

    Animator anim;
    PlayerCtrl playerCtrl_script;
    public Transform Numbers;
    int count;
    public Color blue;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        


        //���ڷ��� ��ġ
        for (int i = 0; i < 10; i++)
        {
            Sprite temp = Numbers.GetChild(i).GetComponent<Image>().sprite;
            int rand = Random.Range(0, 10);
            Numbers.GetChild(i).GetComponent<Image>().sprite = Numbers.GetChild(rand).GetComponent<Image>().sprite;
            Numbers.GetChild(rand).GetComponent<Image>().sprite = temp;

        }

    }

    //�̼ǽ���
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //��ư�ʱ�ȭ
        for (int i = 0; i < Numbers.childCount; i++)
        {
            Numbers.GetChild(i).GetComponent<Image>().color = Color.white;
        }

        count = 1;
    }
    //������ư ������ ȣ��
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }

    //���ڹ�ư ������ ȣ��
    public void ClickNumber()
    {
        if (count.ToString() == EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name)
        {
            //������
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = blue;
            count++;

            //�������� üũ
            if (count == 11)
            {
                Invoke("MissionSuccess", 0.5f);
            }
        }
    }

    //�̼Ǽ����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
