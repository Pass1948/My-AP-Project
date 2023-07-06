using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerTurn : BaseState
{
    public PlayerTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }
    public override void Enter()
    {
        GameManager.Event.RemoveEvent(EventType.EnemyTurn);
        GameManager.Event.RemoveEvent(EventType.Sucess_ET);
        GameManager.Event.RemoveEvent(EventType.Fail_ET);
        // 전투 시작 케릭터와 적 등장 씬, 애니메니션 등 효과 넣기(자유)
        // 처음은 플레이어 선제
        GameManager.Event.PostNotification(EventType.PlayerTurn, bFSM);
        GameManager.Event.AddListener(EventType.Attack, this);
        GameManager.Event.AddListener(EventType.Run, this);
        Debug.Log("플레이어 턴");
    }
    public override void Update() { }
    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.Attack)
        {
            bFSM.ChangeState(BattleState.PlayerAttack);
            GameManager.Event.RemoveEvent(EventType.Attack);
        }
        if(eventType == EventType.Run)
        {
            bFSM.ChangeState(BattleState.PlayerRun);
        }
    }

    public override void Exit()
    {
        // 턴 넘기기
        Debug.Log("턴넘김");
    }
}