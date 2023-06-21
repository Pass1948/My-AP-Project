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
        // ���� ���� �ɸ��Ϳ� �� ���� ��, �ִϸ޴ϼ� �� ȿ�� �ֱ�(����)
        // ó���� �÷��̾� ����
        Debug.Log("�÷��̾� ��");
        GameManager.Event.AddListener(EventType.PlayerActionEnd, this);           // ������ �ޱ�
        GameManager.Event.AddListener(EventType.EnemyDied, this);               // �� óġ �ޱ�
    }
    public override void Update() { }
    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        string result = string.Format("���� �̺�Ʈ ���� :  {0}, �̺�Ʈ ������ ������Ʈ : {1}", eventType, Sender.gameObject.name.ToString());
        Debug.Log(result);
        if (eventType == EventType.PlayerActionEnd)                           // PlayerState�� Idel�����ϰ��
        {
            bFSM.ChangeState(BattleState.EnemyTurn);                        // �� ������ ����
            GameManager.Event.RemoveEvent(EventType.PlayerActionEnd);
        }
        if (eventType == EventType.EnemyDied)                               // ���� �׾������
        {
            bFSM.ChangeState(BattleState.Win);                              // ���� �¸�
        }
    }

    public override void Exit()
    {
        // �� �ѱ��
        Debug.Log("�ϳѱ�");
    }
}