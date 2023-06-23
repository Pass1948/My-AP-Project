using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventuringState : BaseState
{
    public AdventuringState(AdventureFSM aFSM)
    {
        this.aFSM = aFSM;
    }

    public override void Enter()
    {
        Debug.Log("��庥ó����");
        GameManager.Event.AddListener(EventType.EnemyMeeting, this);
        GameManager.Event.PostNotification(EventType.Adventuring, aFSM);
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("��庥ó����");
        // Scene ��ȯ
        GameManager.Event.RemoveEvent(EventType.EnemyMeeting);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if(eventType == EventType.EnemyMeeting)
        {
            aFSM.ChangeState(AdventureState.Idel);
        }
    }
}
