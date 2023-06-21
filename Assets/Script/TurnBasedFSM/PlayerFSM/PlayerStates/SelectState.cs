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
        GameManager.Event.AddListener(EventType.Attack, this);          // 공격 이벤트 받기
        GameManager.Event.AddListener(EventType.Run, this);             // 도망 이벤트 받기
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        string result = string.Format("받은 이벤트 종류 :  {0}, 이벤트 전달한 오브젝트 : {1}", eventType, Sender.gameObject.name.ToString());
        Debug.Log(result);
        if (eventType == EventType.Attack)                              // 선택지 공격 선택시
        {
            Debug.Log("공격이벤트발생");
            pFSM.ChangeState(PlayerTurnState.Attack);                   // 공격 상태로 변경
        }
        if (eventType == EventType.Run)                                 // 선택지 도망 선택시
        {
            pFSM.ChangeState(PlayerTurnState.Run);                      // 도망 상태로 변경
        }
    }

    public override void Exit()
    {
        Debug.Log("선택완료");
    }
}