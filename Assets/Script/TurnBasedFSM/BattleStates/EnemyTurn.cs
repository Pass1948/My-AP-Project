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
        GameManager.Event.AddListener(EventType.EnemyTurnEnd, this);
        Debug.Log("������");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("�ϳѱ�");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyTurnEnd)                           // PlayerState�� Idel�����ϰ��
        {
            bFSM.ChangeState(BattleState.PlayerTurn);                        // �� ������ ����
            GameManager.Event.RemoveEvent(EventType.EnemyTurnEnd);
        }
        if (eventType == EventType.PlayerDied)                               // ���� �׾������
        {
            bFSM.ChangeState(BattleState.Loss);                              // ���� �¸�
        }
    }
}

