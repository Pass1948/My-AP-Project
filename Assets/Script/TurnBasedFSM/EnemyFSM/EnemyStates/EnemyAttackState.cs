using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackState : BaseState, IEventListener
{
    public EnemyAttackState(NomalEnemyFSM_BT eFSM)
    {
        this.neFSM_BT = eFSM;
    }
    public override void Enter()
    {

        // ��ư�׼��� Ÿ�̹� �����ʿ�(�ڷ�ƾ)
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/EnemyButtonActUI");
        Debug.Log("�� ��ư�׼ǽ���");
        GameManager.Event.AddListener(EventType.Sucess_ET, this);
        GameManager.Event.AddListener(EventType.Fail_ET, this);

        
    }
    public override void Update(){}

    public override void Exit()
    {
        Debug.Log("�� ��������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null) 
    {
        int randomValue = Random.Range(1, 3);
        if (eventType == EventType.Sucess_ET)
        {
            if(randomValue == 1 )
            {
                neFSM_BT.Counter();
                neFSM_BT.ChangeState(NomalEnemyTurnState_BT.EnemyIdle);
            }
            else
            {
                neFSM_BT.Miss();
                neFSM_BT.ChangeState(NomalEnemyTurnState_BT.EnemyIdle);
            }
        }
        if (eventType == EventType.Fail_ET)
        {
            neFSM_BT.EnemyAT();
            neFSM_BT.ChangeState(NomalEnemyTurnState_BT.EnemyIdle);
        }
            
    }


}