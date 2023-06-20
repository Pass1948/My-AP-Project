using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum PlayerTurnState
{
    Idel, Select, Attack, run, Size
}
public class PlayerState : MonoBehaviour
{
    private BaseState[] states;
    public PlayerTurnState curState;
    private void Awake()
    {
        states = new BaseState[(int)PlayerTurnState.Size];
        states[(int)PlayerTurnState.Select] = new SelectState(this);
        states[(int)PlayerTurnState.Attack] = new AttackState(this);
        states[(int)PlayerTurnState.run] = new RunState(this);
        states[(int)PlayerTurnState.Idel] = new IdelState(this);
    }

    private void Start()
    {
        curState = PlayerTurnState.Select;        
        states[(int)curState].Enter();
    }

    private void Update()
    {
        states[(int)curState].Update();                 // ������� ������Ʈ
    }

    public void ChangeState(PlayerTurnState playerTurnState)
    {
        states[(int)curState].Exit();
        curState = playerTurnState;
        states[(int)curState].Enter();
    }
}
public class SelectState : BaseState
{
    public SelectState(PlayerState pFSM)
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
            pFSM.ChangeState(PlayerTurnState.run);                      // ���� ���·� ����
        }
    }

    public override void Exit()
    {
        Debug.Log("���ÿϷ�");
    }
}

public class AttackState : BaseState
{
    public AttackState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("������");
        player = new PlayerController();
        player.Attack();
        // QTE ����
    }
    public override void Update()
    {
        pFSM.ChangeState(PlayerTurnState.Idel);
    }

    public override void Exit()
    {
        Debug.Log("������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null){}

    
}

public class RunState : BaseState
{
    public RunState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("����");
    }

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.PlayerActionEnd, pFSM);
        Debug.Log("��������");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }
    public override void Update() { }
}

public class IdelState : BaseState, IEventListener
{
    public IdelState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        GameManager.Event.PostNotification(EventType.PlayerTurnEnd, pFSM);
        GameManager.Event.AddListener(EventType.EnemyActionEnd, this);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyActionEnd)
        {
            pFSM.ChangeState(PlayerTurnState.Select);
        }
    }

    public override void Exit()
    {
        GameManager.Event.RemoveEvent(EventType.EnemyActionEnd);
        Debug.Log("����� ����");
    }

   
    public override void Update() { }
}



