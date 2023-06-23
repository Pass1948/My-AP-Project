using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectState : BaseState
{
    public SelectState(PlayerFSM pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        GameManager.Event.PostNotification(EventType.PlayerTurn, pFSM);
        GameManager.Event.AddListener(EventType.Attack, this);          // 공격 이벤트 받기
        GameManager.Event.AddListener(EventType.Run, this);             // 도망 이벤트 받기
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

        // 선택지 공격 선택시
        if (eventType == EventType.Attack)                              
        {
            Debug.Log("공격이벤트발생");
            GameManager.Event.RemoveEvent(EventType.Attack);
            pFSM.ChangeState(PlayerTurnState.Attack);                   // 공격 상태로 변경
        }

        // 선택지 도망 선택시
        if (eventType == EventType.Run)                                 
        {
            GameManager.Event.RemoveEvent(EventType.Run);
            pFSM.ChangeState(PlayerTurnState.Run);                      // 도망 상태로 변경
        }
    }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.PlayerTurn);
        Debug.Log("선택완료");
    }
}