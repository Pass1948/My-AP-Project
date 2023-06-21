using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : BaseState
{
    public EnemyTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }
    public override void Enter()
    {
        GameManager.Event.RemoveEvent(EventType.PlayerTurnEnd);
        GameManager.Event.AddListener(EventType.EnemyActionEnd, this);
        Debug.Log("������");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("�ϳѱ�");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyActionEnd)                           // PlayerState�� Idel�����ϰ��
        {
            GameManager.Event.PostNotification(EventType.EnemyTurnEnd, this.bFSM);
            GameManager.Event.RemoveEvent(EventType.EnemyActionEnd);
            bFSM.ChangeState(BattleState.PlayerTurn);                        // �� ������ ����
        }
        if (eventType == EventType.PlayerDied)                               // ���� �׾������
        {
            bFSM.ChangeState(BattleState.Loss);                              // ���� �¸�
        }
    }
}

