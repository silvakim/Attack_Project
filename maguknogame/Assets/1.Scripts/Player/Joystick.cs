using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1.��ƽ �巡��, ����
// 2.�巡���Ѹ�ŭ ĳ���� �̵�

public class Joystick : MonoBehaviour
{
    public RectTransform stick, backGround;

    PlayerCtrl playerCtrl_script;
    Animator anim;

    bool isDrag;
    float limit;

    private void Start()
    {
        playerCtrl_script = GetComponent<PlayerCtrl>();
        anim = GetComponent<Animator>();

        limit = backGround.rect.width * 0.5f;
    }
    private void Update()
    {
        //�巡���ϴ� ����
        if (isDrag)
        {
            Vector2 vec = Input.mousePosition - backGround.position;
            stick.localPosition = Vector2.ClampMagnitude(vec, limit);

            Vector3 dir = (stick.position - backGround.position).normalized;
            transform.position += dir * playerCtrl_script.speed * Time.deltaTime;

            anim.SetBool("isWalk", true);

            //���� �̵�
            if (dir.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            //������ �̵�
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            //�巡�� ������
            if (Input.GetMouseButtonUp(0))
            {
                stick.localPosition = new Vector3(0, 0, 0);
                anim.SetBool("isWalk", false);

                isDrag = false;
            }
        }
    }
    // ��ƽ�� ������ ȣ��
    public void ClickStick()
    {
    isDrag = true;
    }
        
 }

