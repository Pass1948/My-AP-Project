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
        Debug.Log("������");
    }
    public override void Update(){}

    public override void Exit()
    {
        Debug.Log("������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) 
    {
        // QTE ����� �ް� �����ϰ� ����
        if (eventType == EventType.ButtonActResult)
        pFSM.ChangeState(PlayerTurnState.Idel);
    }


}