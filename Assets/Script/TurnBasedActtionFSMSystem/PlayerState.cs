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
        states[(int)curState].Update();                 // 현재상태 업데이트
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
        GameManager.Event.AddListener(EventType.Attack, this);          // 공격 이벤트 받기
        GameManager.Event.AddListener(EventType.Run, this);             // 도망 이벤트 받기
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        string result = string.Format("받은 이벤트 종류 :  {0}, 이벤트 전달한 오브젝트 : {1}", eventType, Sender.gameObject.name.ToString());
        Debug.Log(result);
        if (eventType == EventType.Attack)                              // 선택지 공격 선택시
        {                                                               
            Debug.Log("공격이벤트발생");
            pFSM.ChangeState(PlayerTurnState.Attack);                   // 공격 상태로 변경
        }
        if (eventType == EventType.Run)                                 // 선택지 도망 선택시
        {
            pFSM.ChangeState(PlayerTurnState.run);                      // 도망 상태로 변경
        }
    }

    public override void Exit()
    {
        Debug.Log("선택완료");
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
        Debug.Log("적공격");
        player = new PlayerController();
        player.Attack();
        // QTE 시작
    }
    public override void Update()
    {
        pFSM.ChangeState(PlayerTurnState.Idel);
    }

    public override void Exit()
    {
        Debug.Log("턴종료");
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
        Debug.Log("도망");
    }

    public override void Exit()
    {
        GameManager.Event.PostNotification(EventType.PlayerActionEnd, pFSM);
        Debug.Log("전투종료");
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
        Debug.Log("상대턴 종료");
    }

   
    public override void Update() { }
}



