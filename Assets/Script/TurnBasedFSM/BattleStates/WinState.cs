using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : BaseState
{
    public WinState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("�÷��̾� �¸�");
        // �¸� ui���� �ڷ�ƾ���� �����ش��� scene��ȯ �ڷ�ƾ�� scene��ȯ �ֱ�
    }
    public override void Update() { bFSM.ChangeState(BattleState.Idle); }

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.BattleIdel, bFSM);
        Debug.Log("��������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }
}