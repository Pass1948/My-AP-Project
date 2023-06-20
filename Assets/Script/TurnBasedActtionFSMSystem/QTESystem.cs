using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QTESystem : MonoBehaviour
{
    private int correctKey;          // Ű�Է� ����/���� ����
    private int countingDown;
    private bool isKeyDown = false;

    public void PlayerTurnActtion()
    {
        countingDown = 1;
        StartCoroutine(CountDown());
        // ���߿� passd button ui ������ �ִϸ��̼� ����
        if (!isKeyDown)       // �����Ұ��
        {
           Debug.Log("�Ϲݰ���");
           correctKey = 2;
           StartCoroutine(KeyPressing());
        }
        else
        {
            Debug.Log("ũ��Ƽ��");
            correctKey = 1;
           StartCoroutine(KeyPressing());
        }
    }

    public void EnemyTurnAction()
    {
        countingDown = 1;
        StartCoroutine(CountDown());
        /// ���߿� passd button ui ������ �ִϸ��̼� ����
        if (!isKeyDown)
        {
            Debug.Log("���ع���");
            correctKey = 2;
            StartCoroutine(KeyPressing());
        }
        else
        {
            Debug.Log("�ݰ�");
            correctKey = 1;
            StartCoroutine(KeyPressing());
        }
    }

    IEnumerator KeyPressing()
    {
        if (correctKey == 1)    //  �����������
        {
            countingDown = 2;
            // PassBox.GetComponent<Text>().text = "����"; // ���߿� ũ��Ƽ�� ���� ui��� ���� ü����
            Debug.Log("��ư����");
            yield return new WaitForSeconds(1f);
            correctKey = 0;
            // ��ȿ�� ���� ���� ui �� �ݾ��ִ� ������ ���⿡ �־��ش�
            yield return new WaitForSeconds(1f);
        }
        if (correctKey == 2)  //�����������
        {
            Debug.Log("��ư����");
            countingDown = 2;
            // PassBox.GetComponent<Text>().text = "����"; // ���߿� ũ��Ƽ�� ���� ui��� ���� ü����
            yield return new WaitForSeconds(1f);
            correctKey = 0;
            // ��ȿ�� ���� ���� ui �� �ݾ��ִ� ������ ���⿡ �־��ش�
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator CountDown()
    {
        Debug.Log("��ư�׼� ����");
        yield return new WaitForSeconds(1.5f);
        if (countingDown == 1)
        {
            countingDown = 2;
            correctKey = 0;
            yield return new WaitForSeconds(1f);
        }
    }
}



