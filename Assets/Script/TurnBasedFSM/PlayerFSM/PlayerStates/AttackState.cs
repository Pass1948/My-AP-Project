using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public AttackState(PlayerFSM pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("적공격");
        player = new PlayerController();
        player.Attack();
        // QTE 시작
    }
    public override void Update()
    {
        pFSM.ChangeState(PlayerTurnState.Idel);
    }

    public override void Exit()
    {
        Debug.Log("턴종료");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) { }


}