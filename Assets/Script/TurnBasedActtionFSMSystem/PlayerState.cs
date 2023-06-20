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
    private UnityEvent action;
    public SelectState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("����");
        GameManager.Event.AddListener(EventType.Run, this);
        GameManager.Event.AddListener(EventType.Attack, this);
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        string result = string.Format("���� �̺�Ʈ ���� :  {0}, �̺�Ʈ ������ ������Ʈ : {1}", eventType, Sender.gameObject.name.ToString());
        Debug.Log(result);
        if (eventType == EventType.Attack)
        {
            Debug.Log("�����̺�Ʈ�߻�");
            pFSM.ChangeState(PlayerTurnState.Attack);
        }
        if (eventType == EventType.Run)
        {
            pFSM.ChangeState(PlayerTurnState.run);
        }
    }

    public override void Exit()
    {
        Debug.Log("���ÿϷ�");
    }

    public override void Update()
    {
    }
}

public class AttackState : BaseState
{
    private PlayerController player;
    private EnemyController enemy;

    public AttackState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("������");
    }

    public override void Exit()
    {
        Debug.Log("������");
        pFSM.ChangeState(PlayerTurnState.Idel);

    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }

    public override void Update(){}
}

public class RunState : BaseState
{
    public RunState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }

    public override void Update()
    {
        
    }
}

public class IdelState : BaseState, IEventListener
{
    public IdelState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
    }

    public override void Exit()
    {
        Debug.Log("����� ����");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyTurnEnd)
        {
            pFSM.ChangeState(PlayerTurnState.Select);
        }
    }

    public override void Update(){}
}



