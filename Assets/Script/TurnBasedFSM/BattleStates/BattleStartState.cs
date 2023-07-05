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
        // 시작 준비 애니메이션등 효과 넣기
        // 배틀 BGM재생
    }

    public override void Update() 
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }
}
