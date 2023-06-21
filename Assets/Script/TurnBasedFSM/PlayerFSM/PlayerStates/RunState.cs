using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(PlayerFSM pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("����");
    }

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.PlayerActionEnd, pFSM);
        Debug.Log("��������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }
    public override void Update() { }
}
