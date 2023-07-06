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
        GameManager.Event.RemoveEvent(EventType.EnemyTurn);
        GameManager.Event.RemoveEvent(EventType.Sucess_ET);
        GameManager.Event.RemoveEvent(EventType.Fail_ET);
        // ���� ���� �ɸ��Ϳ� �� ���� ��, �ִϸ޴ϼ� �� ȿ�� �ֱ�(����)
        // ó���� �÷��̾� ����
        GameManager.Event.PostNotification(EventType.PlayerTurn, bFSM);
        GameManager.Event.AddListener(EventType.Attack, this);
        GameManager.Event.AddListener(EventType.Run, this);
        Debug.Log("�÷��̾� ��");
    }
    public override void Update() { }
    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.Attack)
        {
            bFSM.ChangeState(BattleState.PlayerAttack);
            GameManager.Event.RemoveEvent(EventType.Attack);
        }
        if(eventType == EventType.Run)
        {
            bFSM.ChangeState(BattleState.PlayerRun);
        }
    }

    public override void Exit()
    {
        // �� �ѱ��
        Debug.Log("�ϳѱ�");
    }
}