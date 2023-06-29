using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossState : BaseState
{
    public LossState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        GameManager.Event.PostNotification(EventType.Loss, bFSM);
        GameManager.Event.RemoveEvent(EventType.PlayerDied);
        Debug.Log("플레이어 패배"); 
        // 패배 ui띄우고 코루틴으로 간격준다음 scene전환 코루틴에 scene전환 넣기
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

