using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public PatrolState(NomalEnemyFSM_AD neFSM_AD)
    {
        this.neFSM_AD = neFSM_AD;
    }
    public override void Enter()
    {

    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }

    public override void Exit()
    {

    }
}
