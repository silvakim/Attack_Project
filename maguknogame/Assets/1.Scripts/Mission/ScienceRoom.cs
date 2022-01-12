using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScienceRoom : MonoBehaviour
{
    public Text inputText, KeyCode;


    Animator anim;
    PlayerCtrl playerCtrl_script;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        //Ű�ڵ� ��������
        for (int i = 0; i < 2; i++)
        {

            KeyCode.text += Random.Range(0, 9);

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
    //���ڹ�ư ������ ȣ��
    public void ClickNumber()
    {
        if (inputText.text.Length <= 1)
        {
            inputText.text += EventSystem.current.currentSelectedGameObject.name;
        }
        
    }
    //������ư ������ ȣ��
    public void ClickDelete()
    {
        if(inputText.text != "")
        {
            inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
        }
    }
    //üũ��ư ������ ȣ��
    public void ClickCheck()
    {
        if(inputText.text == KeyCode.text)
        {
            MissionSuccess();
        }
    }

    //�̼Ǽ����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
