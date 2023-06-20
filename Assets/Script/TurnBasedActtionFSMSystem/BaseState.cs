using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BaseState : IEventListener
{
    

    protected BattleFSM bFSM;
    protected PlayerState pFSM;
    public bool playerIsLive = false;
    public bool enemyIsLive = false;

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
    public abstract void OnEvent(EventType eventType, Component Sender, object Param = null);
}
