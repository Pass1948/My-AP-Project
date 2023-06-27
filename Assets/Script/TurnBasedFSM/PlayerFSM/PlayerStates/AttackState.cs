using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public AttackState(PlayerFSM_BT pFSM)
    {
        this.pFSM_BT = pFSM;
    }
    public override void Enter()
    {
        GameManager.Event.AddListener(EventType.ButtonActResult, this);
        Debug.Log("������");
    }
    public override void Update(){}

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.ButtonActResult);
        Debug.Log("��������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) 
    {
        if (eventType == EventType.ButtonActResult)
        pFSM_BT.ChangeState(PlayerTurnState.Idle);
    }


}