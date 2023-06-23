using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEsystemManager : MonoBehaviour
{
    private int correctKey;          // 키입력 성공/실패 여부

    public void Attack()
    {
        Debug.Log("일반공격");
        correctKey = 2;
        StartCoroutine(KeyPressingRoutine());
    }

    public void Critical()
    {
        Debug.Log("크리티컬");
        correctKey = 1;
        StartCoroutine(KeyPressingRoutine());
    }

    IEnumerator KeyPressingRoutine()
    {
        if (correctKey == 1)    //  성공했을경우
        {
            Debug.Log("버튼성공");
            correctKey = 0;
            yield return new WaitForSecondsRealtime(1f);
        }
        if (correctKey == 2)  //실패했을경우
        {
            Debug.Log("버튼실패");
            correctKey = 0;
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
