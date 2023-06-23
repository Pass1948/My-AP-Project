using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BaseState
{
    public BattleStartState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        // Scene불러오기, 로딩등
    }

    public override void Update() 
    {
        bFSM.ChangeState(BattleState.PlayerTurn);
    }

    public override void Exit()
    {
        
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }
}
