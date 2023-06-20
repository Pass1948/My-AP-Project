using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public SelectState(PlayerState pFSM)
    {
        this.pFSM = pFSM;
    }
    public override void Enter()
    {
        Debug.Log("선택");
        GameManager.Event.AddListener(EventType.PlayerTurn, this);
        GameManager.Event.AddListener(EventType.Attack, this);
    }

    public override void Update() 
    {

    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        string result = string.Format("받은 이벤트 종류 :  {0}, 이벤트 전달한 오브젝트 : {1}", eventType, Sender.gameObject.name.ToString());
        Debug.Log(result);
        switch (eventType)
        {
            case EventType.Attack:
                Debug.Log("공격이벤트발생");
                pFSM.ChangeState(PlayerTurnState.Attack);
                break;
            case EventType.Run:
                Debug.Log("공격이벤트발생");
                pFSM.ChangeState(PlayerTurnState.run);
                break;
        }
    }

    public override void Exit()
    {
        Debug.Log("선택완료");
    }
    
}

public class AttackState : BaseState
{
    protected PlayerState pFSM;
    private PlayerController player;
    private EnemyController enemy;

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
        pFSM.ChangeState(PlayerTurnState.Idel);

    }
    public override void Update(){}
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
        GameManager.Event.PostNotification(EventType.PlayerTurnEnd, this);
        GameManager.Event.AddListener(EventType.EnemyTurnEnd, this);
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



