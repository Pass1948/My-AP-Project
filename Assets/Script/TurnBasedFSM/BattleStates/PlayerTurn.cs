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
        // 전투 시작 케릭터와 적 등장 씬, 애니메니션 등 효과 넣기(자유)
        // 처음은 플레이어 선제
        GameManager.UI.ShowInGameUI<InGameUI>("UI/HPUI");
        GameManager.UI.ShowInGameUI<InGameUI>("UI/SelectBoxUI");
        Debug.Log("플레이어 턴");
        GameManager.Event.AddListener(EventType.PlayerTurnEnd, this);           // 턴종료 받기
        GameManager.Event.AddListener(EventType.EnemyDied, this);
    }
    public override void Update() { }
    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerTurnEnd)                           // PlayerState가 Idel상태일경우
        {
            GameManager.Event.RemoveEvent(EventType.PlayerTurnEnd);
            bFSM.ChangeState(BattleState.EnemyTurn);  
        }
        if (eventType == EventType.EnemyDied)                               // 적이 죽었을경우
        {
            bFSM.ChangeState(BattleState.Win);                              // 전투 승리
        }
    }

    public override void Exit()
    {
        // 턴 넘기기
        Debug.Log("턴넘김");
    }
}