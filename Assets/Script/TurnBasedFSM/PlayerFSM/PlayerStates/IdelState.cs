using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdelState : BaseState
{
    public IdelState(PlayerFSM pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("대기상태");
        GameManager.Event.PostNotification(EventType.PlayerTurnEnd, pFSM);
        GameManager.Event.AddListener(EventType.EnemyTurnEnd, this);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyTurnEnd)
        {
            pFSM.ChangeState(PlayerTurnState.Select);
        }
    }

    public override void Exit()
    {
        Debug.Log("상대턴 종료");
    }


    public override void Update() { }
}
