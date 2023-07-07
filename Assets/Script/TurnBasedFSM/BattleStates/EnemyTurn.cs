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
        GameManager.Event.PostNotification(EventType.EnemyTurn, bFSM);
        GameManager.Event.AddListener(EventType.PlayerDied, this);
        GameManager.Event.AddListener(EventType.EnemyTurnEnd, this);
        GameManager.Event.AddListener(EventType.EnemyDied, this);
        GameManager.Event.AddListener(EventType.EnemyRun, this);
        Debug.Log("몬스터턴");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("턴넘김");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case EventType.EnemyTurnEnd:
                bFSM.ChangeState(BattleState.PlayerTurn);
                break;
            case EventType.EnemyDied:
                GameManager.Event.PostNotification(EventType.Win, bFSM);
                bFSM.ChangeState(BattleState.Win);
                break;
            case EventType.PlayerDied:
                GameManager.Event.PostNotification(EventType.Loss, bFSM);
                bFSM.ChangeState(BattleState.Loss);
                break;
            case EventType.EnemyRun:
                GameManager.Event.PostNotification(EventType.Draw, bFSM);
                bFSM.ChangeState(BattleState.EnemyRun);
                break;
        }
    }

}

