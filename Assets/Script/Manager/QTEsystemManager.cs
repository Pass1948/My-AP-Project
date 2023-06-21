using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEsystemManager : MonoBehaviour, IEventListener
{
    private PlayerController player;
    private EnemyController enemy;
    private int correctKey;          // Ű�Է� ����/���� ����
    private int countingDown;
    private bool isKeyDown = false;

    private void Awake()
    {
        GameManager.Event.RemoveEvent(EventType.SelectAttack);
        GameManager.Event.RemoveEvent(EventType.EnemyTurnEnd);
        GameManager.Event.AddListener(EventType.SelectTarget, this);
        GameManager.Event.AddListener(EventType.PressButton, this);
        GameManager.Event.AddListener(EventType.PressFail, this);
    }
    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PressButton)
        {
            Debug.Log("ũ��Ƽ��");
            correctKey = 1;
            StartCoroutine(KeyPressingRoutine());
        }
        if (eventType == EventType.PressFail)
        {
            Debug.Log("�Ϲݰ���");
            correctKey = 2;
            player = new PlayerController();
            player.Attack();
            StartCoroutine(KeyPressingRoutine());
        }

    }
    public void EnemyTurnAction()
    {
        /// ���߿� passd button ui ������ �ִϸ��̼� ����
        if (!isKeyDown)
        {
            Debug.Log("���ع���");
            correctKey = 2;
            StartCoroutine(KeyPressingRoutine());
        }
        else
        {
            Debug.Log("�ݰ�");
            correctKey = 1;
            StartCoroutine(KeyPressingRoutine());
        }
    }

    IEnumerator KeyPressingRoutine()
    {
        if (correctKey == 1)    //  �����������
        {
            Debug.Log("��ư����");
            correctKey = 0;
            GameManager.Event.PostNotification(EventType.ButtonActResult, this);
            yield return new WaitForSecondsRealtime(1f);
        }
        if (correctKey == 2)  //�����������
        {
            Debug.Log("��ư����");
            correctKey = 0;
            GameManager.Event.PostNotification(EventType.ButtonActResult, this);
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
