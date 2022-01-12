using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
///  비동기 로드 (LoadSceneAsyne)을 위해 코루틴을 사용하는데ㅣ,
///  == 씬을 불러올때 멈추지 않고 다른작업 수행가능
///  
///  로드씬함수로 씬을 불러오면 완료될때까지는 다른작업 수행 하지 않음. 확인 
/// 
/// </summary>

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    public Button buttonvisible;

    private void Start()
    {
        StartCoroutine(LoadScene());  //스타트 함수안에서 LoadScene 코루틴을 시작한다.
        //Button btn = buttonvisible.GetComponent<Button>();


        IEnumerator LoadScene()
        {
            yield return null;
            AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenuScenes");   //로드씬Asyne이 Asyneoperation을 반환하니 담아준다. ------------->나를 위하여 메인메뉴로 들어가는 씬.
            operation.allowSceneActivation = false;

            //operation.isDone;               //Asyneoperation의 속성중 하나 IsDone. -> 작업완료 유무를 boolean 형으로 반환한다. 
            //operation.progress;                //progress는 진행정도를 float형 0,1을 반환(0 = 진행중 ㅡ 1 = 진행완료)
            //operation.allowSceneActivation;    // allowSceneActivation은 로딩이 완료되면 바로 씬을 넘기고.false면 progres가 0.9f 에서 멈춤. 이때 다시 true를 해야 불러온 씬으로 넘길 수 있음.


            //반복문 시작해서 silder의 값을 매 프레임 증가시킨다. 과정바값이 1보다 작을때
            //로딩이 끝나서 isDone이 true가 될때까지 계속해서 반복한다. 
            while (!operation.isDone)
            {
                yield return null;
                //슬라이더의 값이 1이 될때까지 계속증가시켜주기위해서 조건문. 그리고
                if (progressbar.value < 0.9f)
                {
                    //움직이는 발판에서 사용했던(?)  MoveTowards 이용해서 value값을 조금씩 증가시켜주면 됨 
                    //내가 생각한 답. Progressbar.value++;
                    //정답 아래 시간에 따라서 계속 증가
                    progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
                }
                else if (operation.progress >= 0.9f)
                {
                    progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
                }

                //// 값이 1과 같거나 커지면, text를 변경 ->필드에 선언해준 변수로 text변경
                //if (progressbar.value >= 1f)
                //{
                //    loadtext.text = "Press AnyButton";
                //}


                // 이제 로딩바가 꽉 차고 Progress가 0.9f,1f 가 됬을때----> //여기서 왜 operation.progress >= 0.9f?  오퍼레이션.과정이 0.9초보다 클때? //과정바 가 1일때는 1을 넘어갔을때는 이해가 됨
                if (progressbar.value >= 1f && operation.progress >= 0.9f)
                {

                    operation.allowSceneActivation = true; //코루틴에서 선언한 변수.allowSceneActivation = true로 진행. 

                }

            }///페이드인 페이드 아웃 효과 적용중.
        }

    }
}