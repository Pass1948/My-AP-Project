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
        GameManager.Event.RemoveEvent(EventType.PlayerTurnEnd);
        GameManager.Event.AddListener(EventType.EnemyActionEnd, this);
        Debug.Log("몬스터턴");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("턴넘김");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyActionEnd)                           // PlayerState가 Idel상태일경우
        {
            GameManager.Event.PostNotification(EventType.EnemyTurnEnd, this.bFSM);
            GameManager.Event.RemoveEvent(EventType.EnemyActionEnd);
            bFSM.ChangeState(BattleState.PlayerTurn);                        // 적 턴으로 변경
        }
        if (eventType == EventType.PlayerDied)                               // 적이 죽었을경우
        {
            bFSM.ChangeState(BattleState.Loss);                              // 전투 승리
        }
    }
}

