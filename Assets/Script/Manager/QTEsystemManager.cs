using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEsystemManager : MonoBehaviour
{
    private int correctKey;          // Ű�Է� ����/���� ����

    public void Attack()
    {
        Debug.Log("�Ϲݰ���");
        correctKey = 2;
        StartCoroutine(KeyPressingRoutine());
        GameManager.Event.PostNotification(EventType.ButtonActResult, this);
    }

    public void Critical()
    {
        Debug.Log("ũ��Ƽ��");
        correctKey = 1;
        StartCoroutine(KeyPressingRoutine());
        GameManager.Event.PostNotification(EventType.ButtonActResult, this);
    }

    IEnumerator KeyPressingRoutine()
    {
        if (correctKey == 1)    //  �����������
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Debug.Log("��ư����");
            correctKey = 0;
            yield break;
        }
        if (correctKey == 2)  //�����������
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Debug.Log("��ư����");
            correctKey = 0;
            yield break;
        }
    }
}
