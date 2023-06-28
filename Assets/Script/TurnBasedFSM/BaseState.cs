using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BaseState : IEventListener
{
    protected BattleFSM bFSM;
    protected PlayerFSM_BT pFSM_BT;
    protected NomalEnemyFSM_BT neFSM_BT;

    protected AdventureFSM aFSM;

    protected NomalEnemyFSM_AD neFSM_AD;

    public abstract void Enter();              // ���� ���� 
    public abstract void Update();             // ��� �ൿ��
    public abstract void OnEvent(EventType eventType, Component Sender, object Param = null);       // ���� �ൿ
    public abstract void Exit();               // ��������
    
}
