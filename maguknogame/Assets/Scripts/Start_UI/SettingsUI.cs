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

    private void Awake()   //어웨이크 이벤트 콜백함수를 만듬
    {
        animator = GetComponent<Animator>();  //같은 게임오브젝트에 붙어있는 에니메이터 컴포넌트를 가져와서 animator 변수에 저장
    }

    private void OnEnable()  //gameobject가 활성화될때, 호출되는 onEnable이벤트 콜백함수를 만들고
    {
        switch (CommonSettings.controlType) // 플레이어 세팅의 controlType에 따라서(<-Switch조건) 현재 활성된 조작모드의 버튼 색깔 체인지.
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

    public void SetControlMode(int ControlType)   // setControlmode 함수를 만들어서 매개변수로 받아온 숫자에 따라
    {
        CommonSettings.controlType = (EControlType)ControlType; //playersettings의 controltype을 변경하고, 역시 벼튼색깔을 바꾸는 코드

        //Onenable것들 복사
        switch (CommonSettings.controlType) // 플레이어 세팅의 controlType에 따라서 현재 활성된 조작모드의 버튼 색깔 체인지.
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

    private IEnumerator CloseAfterDelay()  //ui오브젝트를 비활성화시킬 closeafterDelay코루틴함수
    {
        animator.SetTrigger("close");    //close함수가 호출되면 closeAfterDelay코루틴함수를 호출한다.
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }


}