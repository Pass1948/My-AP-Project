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
        GameManager.Event.AddListener(EventType.PlayerTurnEnd, this);
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerTurnEnd)
        {
            eFSM.ChangeState(EnemyTurnState.EnemyAttack);
        }
    }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.ButtonActResult);
        GameManager.Event.RemoveEvent(EventType.PlayerTurnEnd);
        Debug.Log("적 움직임");
    }
}
