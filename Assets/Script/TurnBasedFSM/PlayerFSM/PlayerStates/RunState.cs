using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public RunState(PlayerFSM_BT pFSM)
    {
        this.pFSM_BT = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("����");
    }

    public override void Exit()
    {
        
        Debug.Log("��������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }
    public override void Update() { }
}
