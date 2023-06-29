using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : BaseState
{
    public WinState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        GameManager.Event.PostNotification(EventType.Win, bFSM);
        GameManager.Event.RemoveEvent(EventType.EnemyDied);
        Debug.Log("플레이어 승리");
        // 승리 ui띄우고 코루틴으로 간격준다음 scene전환 코루틴에 scene전환 넣기
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