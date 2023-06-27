using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleState_BT : BaseState
{
    public IdleState_BT(PlayerFSM_BT pFSM)
    {
        this.pFSM_BT = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("대기상태");
        GameManager.Event.PostNotification(EventType.PlayerTurnEnd, pFSM_BT);
        GameManager.Event.PostNotification(EventType.PlayerActionEnd, pFSM_BT);
        GameManager.Event.AddListener(EventType.EnemyDied, this);
        GameManager.Event.AddListener(EventType.EnemyisLive, this);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyDied)
        {
            return;
        }
        if (eventType == EventType.EnemyisLive)
        {
            pFSM_BT.ChangeState(PlayerTurnState.Select);
        }
    }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.EnemyisLive);
        Debug.Log("상대턴 종료");
    }


    public override void Update() { }
}
