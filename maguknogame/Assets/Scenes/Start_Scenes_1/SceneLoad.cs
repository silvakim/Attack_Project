using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
///  �񵿱� �ε� (LoadSceneAsyne)�� ���� �ڷ�ƾ�� ����ϴµ���,
///  == ���� �ҷ��ö� ������ �ʰ� �ٸ��۾� ���డ��
///  
///  �ε���Լ��� ���� �ҷ����� �Ϸ�ɶ������� �ٸ��۾� ���� ���� ����. Ȯ�� 
/// 
/// </summary>

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    public Button buttonvisible;

    private void Start()
    {
        StartCoroutine(LoadScene());  //��ŸƮ �Լ��ȿ��� LoadScene �ڷ�ƾ�� �����Ѵ�.
        //Button btn = buttonvisible.GetComponent<Button>();


        IEnumerator LoadScene()
        {
            yield return null;
            AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenuScenes");   //�ε��Asyne�� Asyneoperation�� ��ȯ�ϴ� ����ش�. ------------->���� ���Ͽ� ���θ޴��� ���� ��.
            operation.allowSceneActivation = false;

            //operation.isDone;               //Asyneoperation�� �Ӽ��� �ϳ� IsDone. -> �۾��Ϸ� ������ boolean ������ ��ȯ�Ѵ�. 
            //operation.progress;                //progress�� ���������� float�� 0,1�� ��ȯ(0 = ������ �� 1 = ����Ϸ�)
            //operation.allowSceneActivation;    // allowSceneActivation�� �ε��� �Ϸ�Ǹ� �ٷ� ���� �ѱ��.false�� progres�� 0.9f ���� ����. �̶� �ٽ� true�� �ؾ� �ҷ��� ������ �ѱ� �� ����.


            //�ݺ��� �����ؼ� silder�� ���� �� ������ ������Ų��. �����ٰ��� 1���� ������
            //�ε��� ������ isDone�� true�� �ɶ����� ����ؼ� �ݺ��Ѵ�. 
            while (!operation.isDone)
            {
                yield return null;
                //�����̴��� ���� 1�� �ɶ����� ������������ֱ����ؼ� ���ǹ�. �׸���
                if (progressbar.value < 0.9f)
                {
                    //�����̴� ���ǿ��� ����ߴ�(?)  MoveTowards �̿��ؼ� value���� ���ݾ� ���������ָ� �� 
                    //���� ������ ��. Progressbar.value++;
                    //���� �Ʒ� �ð��� ���� ��� ����
                    progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
                }
                else if (operation.progress >= 0.9f)
                {
                    progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
                }

                //// ���� 1�� ���ų� Ŀ����, text�� ���� ->�ʵ忡 �������� ������ text����
                //if (progressbar.value >= 1f)
                //{
                //    loadtext.text = "Press AnyButton";
                //}


                // ���� �ε��ٰ� �� ���� Progress�� 0.9f,1f �� ������----> //���⼭ �� operation.progress >= 0.9f?  ���۷��̼�.������ 0.9�ʺ��� Ŭ��? //������ �� 1�϶��� 1�� �Ѿ������ ���ذ� ��
                if (progressbar.value >= 1f && operation.progress >= 0.9f)
                {

                    operation.allowSceneActivation = true; //�ڷ�ƾ���� ������ ����.allowSceneActivation = true�� ����. 

                }

            }///���̵��� ���̵� �ƿ� ȿ�� ������.
        }

    }
}