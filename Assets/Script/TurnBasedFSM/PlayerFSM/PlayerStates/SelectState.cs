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
        GameManager.Event.AddListener(EventType.Attack, this);          // ���� �̺�Ʈ �ޱ�
        GameManager.Event.AddListener(EventType.Run, this);             // ���� �̺�Ʈ �ޱ�
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        string result = string.Format("���� �̺�Ʈ ���� :  {0}, �̺�Ʈ ������ ������Ʈ : {1}", eventType, Sender.gameObject.name.ToString());
        Debug.Log(result);
        if (eventType == EventType.Attack)                              // ������ ���� ���ý�
        {
            Debug.Log("�����̺�Ʈ�߻�");
            pFSM.ChangeState(PlayerTurnState.Attack);                   // ���� ���·� ����
        }
        if (eventType == EventType.Run)                                 // ������ ���� ���ý�
        {
            pFSM.ChangeState(PlayerTurnState.Run);                      // ���� ���·� ����
        }
    }

    public override void Exit()
    {
        Debug.Log("���ÿϷ�");
    }
}