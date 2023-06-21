using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunState : BaseState
{
    public EnemyRunState(EnemyFSM pFSM)
    {
        this.eFSM = pFSM;
    }
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }
    public override void Update() { }
}