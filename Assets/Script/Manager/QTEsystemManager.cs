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
        GameManager.Event.PostNotification(EventType.ButtonActResult, this);
    }

    public void Critical()
    {
        Debug.Log("크리티컬");
        correctKey = 1;
        StartCoroutine(KeyPressingRoutine());
        GameManager.Event.PostNotification(EventType.ButtonActResult, this);
    }

    IEnumerator KeyPressingRoutine()
    {
        if (correctKey == 1)    //  성공했을경우
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Debug.Log("버튼성공");
            correctKey = 0;
            yield break;
        }
        if (correctKey == 2)  //실패했을경우
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Debug.Log("버튼실패");
            correctKey = 0;
            yield break;
        }
    }
}
