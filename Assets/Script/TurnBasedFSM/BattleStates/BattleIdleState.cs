using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleIdleState : BaseState
{
    public BattleIdleState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        GameManager.Event.AddListener(EventType.AdventureIdel, this);
    }

    public override void Update() { }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.AdventureIdel);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if(eventType == EventType.AdventureIdel)
        {
            bFSM.ChangeState(BattleState.Start);
        }
    }
}
