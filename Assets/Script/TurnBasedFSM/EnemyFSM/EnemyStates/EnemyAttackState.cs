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
        Debug.Log("�� ��ư�׼ǽ���");
    }
    public override void Update()
    {
        // ��ư�׼� 
        eFSM.ChangeState(EnemyTurnState.enemyIdel);
    }

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.EnemyActionEnd, eFSM);
        GameManager.Event.PostNotification(EventType.EnemyTurnEnd, eFSM);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) { }


}