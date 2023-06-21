using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunState : BaseState
{
    public EnemyRunState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("몬스터 도주");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("전투종료");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }
}
