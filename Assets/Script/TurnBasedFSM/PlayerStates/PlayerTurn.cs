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
        GameManager.UI.ShowInGameUI<InGameUI>("UI/HPUI");
        GameManager.UI.ShowInGameUI<SelectBoxUI>("UI/SelectBoxUI");
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
            GameManager.Event.RemoveEvent(EventType.Attack);
            bFSM.ChangeState(BattleState.PlayerAttack);
        }
        if(eventType == EventType.Run)
        {
            GameManager.Event.RemoveEvent(EventType.Run);
            bFSM.ChangeState(BattleState.PlayerRun);
        }
    }

    public override void Exit()
    {
        // �� �ѱ��
        Debug.Log("�ϳѱ�");
    }
}