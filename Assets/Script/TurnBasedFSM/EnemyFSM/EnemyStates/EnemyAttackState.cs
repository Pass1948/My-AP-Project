using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackState : BaseState, IEventListener
{
    public EnemyAttackState(EnemyFSM pFSM)
    {
        this.eFSM = pFSM;
    }
    public override void Enter()
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PlayerButtonActUI");
        GameManager.Event.AddListener(EventType.PlayerisLive, this);
        Debug.Log("�� ��ư�׼ǽ���");
    }
    public override void Update(){}

    public override void Exit()
    {
        Debug.Log("�� ��������");
        GameManager.Event.RemoveEvent(EventType.PlayerisLive);
        GameManager.Event.PostNotification(EventType.EnemyTurnEnd, eFSM);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) 
    {
        if (eventType == EventType.PlayerDied)
            return;
        if (eventType == EventType.PlayerisLive)
            eFSM.ChangeState(EnemyTurnState.EnemyIdle);
    }


}