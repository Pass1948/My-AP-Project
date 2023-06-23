using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdelState : BaseState
{
    public EnemyIdelState(EnemyFSM eFSM)
    {
        this.eFSM = eFSM;
    }
    public override void Enter()
    {
        Debug.Log("적대기");
        GameManager.Event.AddListener(EventType.PlayerActionEnd, this);
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerActionEnd)
        {
            eFSM.ChangeState(EnemyTurnState.EnemyAttack);
        }
    }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.PlayerActionEnd);
        Debug.Log("적 움직임");
    }
}
