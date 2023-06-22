using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerTurn : BaseState
{
    public PlayerTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }
    public override void Enter()
    {
        // ���� ���� �ɸ��Ϳ� �� ���� ��, �ִϸ޴ϼ� �� ȿ�� �ֱ�(����)
        // ó���� �÷��̾� ����
        Debug.Log("�÷��̾� ��");
        GameManager.Event.AddListener(EventType.PlayerTurnEnd, this);           // ������ �ޱ�
        GameManager.Event.AddListener(EventType.EnemyDied, this);
        GameManager.Event.RemoveEvent(EventType.EnemyActionEnd);
    }
    public override void Update() { }
    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerTurnEnd)                           // PlayerState�� Idel�����ϰ��
        {
            bFSM.ChangeState(BattleState.EnemyTurn);  
        }
        if (eventType == EventType.EnemyDied)                               // ���� �׾������
        {
            bFSM.ChangeState(BattleState.Win);                              // ���� �¸�
        }
    }

    public override void Exit()
    {
        // �� �ѱ��
        Debug.Log("�ϳѱ�");
    }
}