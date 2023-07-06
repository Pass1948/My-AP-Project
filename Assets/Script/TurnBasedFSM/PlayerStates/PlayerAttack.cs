using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : BaseState
{
    public PlayerAttack(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }
    public override void Enter()
    {
        Debug.Log("적공격");
        GameManager.Event.AddListener(EventType.Sucess, this);
        GameManager.Event.AddListener(EventType.Fail, this);
    }
    public override void Update(){}

    public override void Exit()
    {
        Debug.Log("공격종료");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) 
    {
        if (eventType == EventType.Sucess)
        {
            bFSM.playerAT();
        }
        if(eventType == EventType.Fail)
        {
            bFSM.ChangeState(BattleState.EnemyTurn);
        }

    }


}