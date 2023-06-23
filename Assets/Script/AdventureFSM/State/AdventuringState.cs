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
        Debug.Log("어드벤처시작");
        GameManager.Event.AddListener(EventType.EnemyMeeting, this);
        GameManager.Event.PostNotification(EventType.Adventuring, aFSM);
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("어드벤처종료");
        // Scene 전환
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
