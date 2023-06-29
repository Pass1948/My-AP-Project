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
            Debug.Log("��ư����");
            correctKey = 0;
            yield return new WaitForSecondsRealtime(0.5f);

        }
        if (correctKey == 2)  //�����������
        {
            Debug.Log("��ư����");
            correctKey = 0;
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
