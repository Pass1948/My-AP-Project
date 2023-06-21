using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BaseState : IEventListener
{
    protected BattleFSM bFSM;
    protected PlayerFSM pFSM;
    protected EnemyFSM eFSM;
    protected PlayerController player;
    protected EnemyController enemy;

    public abstract void Enter();              // ���� ���� 

    public abstract void Update();             // ��� �ൿ��
    public abstract void OnEvent(EventType eventType, Component Sender, object Param = null);       // ���� �ൿ
    public abstract void Exit();               // ��������
    
}
