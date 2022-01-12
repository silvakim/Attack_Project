using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class KitchenKiller : MonoBehaviour
{


    private float clickTime; // Ŭ�� ���� �ð�
    public float minClickTime = 10f; // �ּ� Ŭ���ð�
    private bool isClick; // Ŭ�� ������ �Ǵ� 

    public Text timeText;
    private float time;

    Animator anim;
    PlayerCtrl playerCtrl_script;
    

   
  
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
       

    }

    
    //�̼ǽ���
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        

}

    // ��ư Ŭ���� �������� ��
    public void ButtonDown()
    {
        isClick = true;
    }

    // ��ư Ŭ���� ������ ��
    public void ButtonUp()
    {
        isClick = false;
        

        // Ŭ�� ���� �ð��� �ּ� Ŭ���ð� �̻��̶��
        if (clickTime == minClickTime)
        {
            Invoke("MissionSuccess", 0.2f);
        }
    }

    private void Update()
    {
        // Ŭ�� ���̶��
        if (isClick)
        {
            // Ŭ���ð� ����
            clickTime += Time.deltaTime;
            time += Time.deltaTime;
            timeText.text = Mathf.Ceil(time).ToString();
            if(timeText.text == "10")
            {
                MissionSuccess();
            }
            

        }

        // Ŭ�� ���� �ƴ϶��
        else
        {
            // Ŭ���ð� �ʱ�ȭ
            clickTime = 0;
            //Ÿ�̸� �ʱ�ȭ
            //timeText.text = "";
            //time = 0f;

        }
    }

    //������ư ������ ȣ��
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    

    //�̼Ǽ����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
        
    }
}
