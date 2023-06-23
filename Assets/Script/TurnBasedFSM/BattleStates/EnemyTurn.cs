using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : BaseState
{
    public EnemyTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }
    public override void Enter()
    {
        GameManager.Event.AddListener(EventType.EnemyTurnEnd, this);
        GameManager.Event.AddListener(EventType.PlayerDied, this);
        Debug.Log("몬스터턴");
    }
    public override void Update() { }

    public override void Exit()
    {
        
        Debug.Log("턴넘김");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyTurnEnd)                           
        {
            GameManager.Event.RemoveEvent(EventType.EnemyTurnEnd); 
            bFSM.ChangeState(BattleState.PlayerTurn);                       
        }
        if (eventType == EventType.PlayerDied)                              
        {
           
           bFSM.ChangeState(BattleState.Loss);                              
        }
    }
}

