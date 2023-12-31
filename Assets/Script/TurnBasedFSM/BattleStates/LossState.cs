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
        Debug.Log("플레이어 패배");
        GameManager.Scene.ADLoadScene("AdventureScene");
        Debug.Log("전투종료");
        // 패배 ui띄우고 코루틴으로 간격준다음 scene전환 코루틴에 scene전환 넣기
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

