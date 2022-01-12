using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsUI : MonoBehaviour
{

    [SerializeField]
    private Button MouseControlButton;

    [SerializeField]
    private Button KeyboardMouseControlButton;
    private Animator animator;

    private void Awake()   //�����ũ �̺�Ʈ �ݹ��Լ��� ����
    {
        animator = GetComponent<Animator>();  //���� ���ӿ�����Ʈ�� �پ��ִ� ���ϸ����� ������Ʈ�� �����ͼ� animator ������ ����
    }

    private void OnEnable()  //gameobject�� Ȱ��ȭ�ɶ�, ȣ��Ǵ� onEnable�̺�Ʈ �ݹ��Լ��� �����
    {
        switch (CommonSettings.controlType) // �÷��̾� ������ controlType�� ����(<-Switch����) ���� Ȱ���� ���۸���� ��ư ���� ü����.
        {
            case EControlType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;

            case EControlType.KeyboardMouse:
                MouseControlButton.image.color = Color.white;
                KeyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }

    public void SetControlMode(int ControlType)   // setControlmode �Լ��� ���� �Ű������� �޾ƿ� ���ڿ� ����
    {
        CommonSettings.controlType = (EControlType)ControlType; //playersettings�� controltype�� �����ϰ�, ���� ��ư������ �ٲٴ� �ڵ�

        //Onenable�͵� ����
        switch (CommonSettings.controlType) // �÷��̾� ������ controlType�� ���� ���� Ȱ���� ���۸���� ��ư ���� ü����.
        {
            case EControlType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;

            case EControlType.KeyboardMouse:
                MouseControlButton.image.color = Color.white;
                KeyboardMouseControlButton.image.color = Color.green;
                break;
        }

    }
    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()  //ui������Ʈ�� ��Ȱ��ȭ��ų closeafterDelay�ڷ�ƾ�Լ�
    {
        animator.SetTrigger("close");    //close�Լ��� ȣ��Ǹ� closeAfterDelay�ڷ�ƾ�Լ��� ȣ���Ѵ�.
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }


}