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
        GameManager.Event.RemoveEvent(EventType.PlayerDied);
        Debug.Log("플레이어 패배"); 
        // 패배 ui띄우고 코루틴으로 간격준다음 scene전환 코루틴에 scene전환 넣기
    }
    public override void Update() { bFSM.ChangeState(BattleState.Idle); }

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.BattleIdel, bFSM);
        Debug.Log("전투종료");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }
}

