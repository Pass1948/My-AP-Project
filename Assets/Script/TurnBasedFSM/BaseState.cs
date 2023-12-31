using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BaseState : IEventListener
{
    protected BattleFSM bFSM;
    protected NomalEnemyFSM_BT neFSM_BT;
    protected GameObject BossSpawner;
    protected GameObject NomalSpawner;

    public abstract void Enter();              // 상태 시작 
    public abstract void Update();             // 즉시 행동용
    public abstract void OnEvent(EventType eventType, Component Sender, object Param = null);       // 상태 행동
    public abstract void Exit();               // 상태종료
    
}
