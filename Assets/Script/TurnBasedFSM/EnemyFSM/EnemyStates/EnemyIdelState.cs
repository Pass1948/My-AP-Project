using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdelState : BaseState
{
    public EnemyIdelState(NomalEnemyFSM_BT eFSM)
    {
        this.neFSM_BT = eFSM;
    }
    public override void Enter()
    {
        Debug.Log("�����");
        GameManager.Event.AddListener(EventType.PlayerActionEnd, this);
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerActionEnd)
        {
            neFSM_BT.ChangeState(NomalEnemyTurnState_BT.EnemyAttack);
        }
    }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.PlayerActionEnd);
        Debug.Log("�� ������");
    }
}
