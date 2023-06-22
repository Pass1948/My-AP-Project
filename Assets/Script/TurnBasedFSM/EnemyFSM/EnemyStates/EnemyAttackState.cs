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
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PlayerButtonActUI");
        Debug.Log("적 버튼액션시작");
    }
    public override void Update(){}

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.EnemyActionEnd, eFSM);
        GameManager.Event.PostNotification(EventType.EnemyTurnEnd, eFSM);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) 
    {
        if (eventType == EventType.ButtonActResult)
            eFSM.ChangeState(EnemyTurnState.EnemyIdel);
    }


}