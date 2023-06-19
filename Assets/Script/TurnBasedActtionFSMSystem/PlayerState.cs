using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        states[(int)curState].Update();                 // 현재상태 업데이트
    }

    public void ChangeState(PlayerTurnState playerTurnState)
    {
        states[(int)curState].Exit();
        curState = playerTurnState;
        states[(int)curState].Enter();
    }
}
public class SelectState : BaseState, IEventListener
{
    protected PlayerState pFSM;

    public SelectState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("선택");
        GameManager.Event.AddListener(EventType.Attack, this);
        GameManager.Event.AddListener(EventType.Run, this);
    }

    public override void Exit()
    {
        Debug.Log("선택완료");
    }

    public override void Update(){}

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case EventType.Attack:
                pFSM.ChangeState(PlayerTurnState.Attack);
                break;
            case EventType.Run:
                pFSM.ChangeState(PlayerTurnState.run);
                break;
        }
    }
}

public class AttackState : BaseState
{
    protected PlayerState pFSM;
    private PlayerController controller;
    private EnemyController enemyController;

    public AttackState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("적공격");
    }

    public override void Exit()
    {
        Debug.Log("턴종료");
        
    }

    public override void Update()
    {
        controller.Attack(enemyController);
        pFSM.ChangeState(PlayerTurnState.Idel);
    }
}

public class RunState : BaseState
{
    protected PlayerState pFSM;

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

    public override void Update()
    {
        
    }
}

public class IdelState : BaseState, IEventListener
{
    protected PlayerState pFSM;

    public IdelState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        GameManager.Event.AddListener(EventType.EnemyTurn, this);
    }

    public override void Exit()
    {
        Debug.Log("상대턴 종료");
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyTurnEnd)
        {
            pFSM.ChangeState(PlayerTurnState.Select);
        }
    }

    public override void Update(){}
}



