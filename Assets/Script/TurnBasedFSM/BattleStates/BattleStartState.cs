using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BaseState
{

    public BattleStartState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        // ���� �غ� �ִϸ��̼ǵ� ȿ�� �ֱ�
        // ��Ʋ BGM���
    }

    public override void Update() 
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.NomalMeet)
        {
            GameManager.Event.RemoveEvent(EventType.NomalMeet);
            GameManager.Resource.Instantiate(NomalSpawner);
            bFSM.ChangeState(BattleState.PlayerTurn);
        }
        if (eventType == EventType.BossMeet)
        {
            GameManager.Event.RemoveEvent(EventType.BossMeet);
            GameManager.Resource.Instantiate(BossSpawner);
            bFSM.ChangeState(BattleState.PlayerTurn);
        }

    }
}
