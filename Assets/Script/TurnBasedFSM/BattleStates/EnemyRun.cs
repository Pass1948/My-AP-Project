using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : BaseState
{
    public EnemyRun(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }
    public override void Enter()
    {
        Debug.Log("응 런이야~");
        GameManager.Event.PostNotification(EventType.ADin, bFSM);
        Debug.Log("전투종료");
    }
    public override void Update() {
        
    }

    public override void Exit()
    {
        
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }
}
