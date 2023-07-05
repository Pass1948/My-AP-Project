using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdelState : BaseState
{
    public EnemyIdelState(NomalEnemyFSM_BT eFSM)
    {
        this.neFSM_BT = eFSM;
    }
    public override void Enter()
    {
        Debug.Log("적대기");
        GameManager.Event.AddListener(EventType.EnemyTurn, this);
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        int randomValue = Random.Range(0, 10);
        if (eventType == EventType.EnemyTurn)
        {
            if(randomValue == 5)
            {
                GameManager.Event.RemoveEvent(EventType.EnemyTurn);
                neFSM_BT.EnemyRun();
            }
            else
            {
                GameManager.Event.RemoveEvent(EventType.EnemyTurn);
                GameManager.Event.PostNotification(EventType.EnemyAttack, neFSM_BT);
                neFSM_BT.ChangeState(NomalEnemyTurnState_BT.EnemyAttack);
            }
            
        }
    }

    public override void Exit()
    {
        Debug.Log("적 움직임");
    }
}
