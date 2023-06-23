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
        GameManager.Event.AddListener(EventType.EnemyStateEnd, this);
        Debug.Log("������");
    }
    public override void Update() { }

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.EnemyTurnEnd, eFSM);
        Debug.Log("�ϳѱ�");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyStateEnd)                           // PlayerState�� Idel�����ϰ��
        {
            GameManager.Event.PostNotification(EventType.EnemyTurnEnd, this.bFSM);
            bFSM.ChangeState(BattleState.PlayerTurn);                        // �� ������ ����
        }
        if (eventType == EventType.PlayerDied)                               // ���� �׾������
        {
            bFSM.ChangeState(BattleState.Loss);                              // ���� �¸�
        }
    }
}

