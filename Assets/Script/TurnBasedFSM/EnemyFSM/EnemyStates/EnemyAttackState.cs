using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState
{
    public EnemyAttackState(EnemyFSM pFSM)
    {
        this.eFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("적 버튼액션시작");
    }
    public override void Update()
    {
        // 버튼액션 
        eFSM.ChangeState(EnemyTurnState.enemyIdel);
    }

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.EnemyActionEnd, eFSM);
        GameManager.Event.PostNotification(EventType.EnemyTurnEnd, eFSM);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) { }


}