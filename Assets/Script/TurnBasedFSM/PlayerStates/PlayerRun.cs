using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : BaseState
{
    public PlayerRun(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }
    public override void Enter()
    {
        Debug.Log("도망");
        GameManager.Scene.ADLoadScene("AdventureScene");
        Debug.Log("전투종료");
    }

    public override void Exit()
    {
        
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }
    public override void Update() { }


}
