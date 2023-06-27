using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectState : BaseState
{
    public SelectState(PlayerFSM_BT pFSM)
    {
        this.pFSM_BT = pFSM;
    }
    public override void Enter()
    {
        GameManager.Event.PostNotification(EventType.PlayerTurn, pFSM_BT);
        GameManager.Event.AddListener(EventType.Attack, this);          // ���� �̺�Ʈ �ޱ�
        GameManager.Event.AddListener(EventType.Run, this);             // ���� �̺�Ʈ �ޱ�
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

        // ������ ���� ���ý�
        if (eventType == EventType.Attack)                              
        {
            Debug.Log("�����̺�Ʈ�߻�");
            GameManager.Event.RemoveEvent(EventType.Attack);
            pFSM_BT.ChangeState(PlayerTurnState.Attack);                   // ���� ���·� ����
        }

        // ������ ���� ���ý�
        if (eventType == EventType.Run)                                 
        {
            GameManager.Event.RemoveEvent(EventType.Run);
            pFSM_BT.ChangeState(PlayerTurnState.Run);                      // ���� ���·� ����
        }
    }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.PlayerTurn);
        Debug.Log("���ÿϷ�");
    }
}