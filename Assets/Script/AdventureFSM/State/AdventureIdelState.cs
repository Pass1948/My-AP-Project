using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureIdelState : BaseState
{
    public AdventureIdelState(AdventureFSM aFSM)
    {
        this.aFSM = aFSM;
    }

    public override void Enter()
    {
        GameManager.Event.AddListener(EventType.BattleIdel, this);
        GameManager.Event.PostNotification(EventType.AdventureIdel, aFSM);
    }
    public override void Update() { }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.BattleIdel);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.BattleIdel)
        {
            aFSM.ChangeState(AdventureState.Adventuring);
        }
    }
}
