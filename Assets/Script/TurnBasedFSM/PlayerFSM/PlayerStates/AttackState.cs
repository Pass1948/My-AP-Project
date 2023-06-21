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
        GameManager.Event.AddListener(EventType.ButtonActResult, this);
        Debug.Log("적공격");
    }
    public override void Update(){}

    public override void Exit()
    {
        Debug.Log("턴종료");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) 
    {
        // QTE 결과를 받고 변경하게 구현
        if (eventType == EventType.ButtonActResult)
        pFSM.ChangeState(PlayerTurnState.Idel);
    }


}