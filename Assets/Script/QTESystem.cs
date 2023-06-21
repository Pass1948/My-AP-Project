using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QTESystem : MonoBehaviour
{
    private int correctKey;          // 키입력 성공/실패 여부
    private int countingDown;
    private bool isKeyDown = false;

    public void PlayerTurnActtion()
    {
        countingDown = 1;
        StartCoroutine(CountDown());
        // 나중에 passd button ui 나오는 애니메이션 적용
        if (!isKeyDown)       // 실패할경우
        {
           Debug.Log("일반공격");
           correctKey = 2;
           StartCoroutine(KeyPressing());
        }
        else
        {
            Debug.Log("크리티컬");
            correctKey = 1;
           StartCoroutine(KeyPressing());
        }
    }

    public void EnemyTurnAction()
    {
        countingDown = 1;
        StartCoroutine(CountDown());
        /// 나중에 passd button ui 나오는 애니메이션 적용
        if (!isKeyDown)
        {
            Debug.Log("피해받음");
            correctKey = 2;
            StartCoroutine(KeyPressing());
        }
        else
        {
            Debug.Log("반격");
            correctKey = 1;
            StartCoroutine(KeyPressing());
        }
    }

    IEnumerator KeyPressing()
    {
        if (correctKey == 1)    //  성공했을경우
        {
            countingDown = 2;
            // PassBox.GetComponent<Text>().text = "성공"; // 나중에 크리티컬 공격 ui출력 으로 체인지
            Debug.Log("버튼성공");
            yield return new WaitForSeconds(1f);
            correctKey = 0;
            // 각효과 마다 나온 ui 는 닫아주는 순서로 여기에 넣어준다
            yield return new WaitForSeconds(1f);
        }
        if (correctKey == 2)  //실패했을경우
        {
            Debug.Log("버튼실패");
            countingDown = 2;
            // PassBox.GetComponent<Text>().text = "실패"; // 나중에 크리티컬 공격 ui출력 으로 체인지
            yield return new WaitForSeconds(1f);
            correctKey = 0;
            // 각효과 마다 나온 ui 는 닫아주는 순서로 여기에 넣어준다
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator CountDown()
    {
        Debug.Log("버튼액션 시작");
        yield return new WaitForSeconds(1.5f);
        if (countingDown == 1)
        {
            countingDown = 2;
            correctKey = 0;
            yield return new WaitForSeconds(1f);
        }
    }
}



