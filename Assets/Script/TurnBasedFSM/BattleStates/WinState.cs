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
        GameManager.Scene.ADLoadScene("AdventureScene");
        Debug.Log("��������");
        // �¸� ui���� �ڷ�ƾ���� �����ش��� scene��ȯ �ڷ�ƾ�� scene��ȯ �ֱ�
    }
    public override void Update() 
    {
    }

    public override void Exit()
    {
        
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }
}