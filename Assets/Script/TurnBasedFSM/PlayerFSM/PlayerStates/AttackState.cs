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
        Debug.Log("������");
        player = new PlayerController();
        player.Attack();
        // QTE ����
    }
    public override void Update()
    {
        pFSM.ChangeState(PlayerTurnState.Idel);
    }

    public override void Exit()
    {
        Debug.Log("������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) { }


}