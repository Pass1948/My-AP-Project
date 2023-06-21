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
        Debug.Log("몬스터턴");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("턴넘김");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyTurnEnd)                           // PlayerState가 Idel상태일경우
        {
            bFSM.ChangeState(BattleState.PlayerTurn);                        // 적 턴으로 변경
            GameManager.Event.RemoveEvent(EventType.EnemyTurnEnd);
        }
        if (eventType == EventType.PlayerDied)                               // 적이 죽었을경우
        {
            bFSM.ChangeState(BattleState.Loss);                              // 전투 승리
        }
    }
}

