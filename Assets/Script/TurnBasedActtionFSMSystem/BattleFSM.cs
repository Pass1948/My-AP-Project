using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static PlayerTurn;

public enum BattleState
{
PlayerTurn, EnemyTurn, Win, Loss, EnemyRun, Size
}

public class BattleFSM : MonoBehaviour
{
private BaseState[] states;
public BattleState curState;
private void Awake()
{
    states = new BaseState[(int)BattleState.Size];
    states[(int)BattleState.PlayerTurn]  = new PlayerTurn(this);
    states[(int)BattleState.EnemyTurn]   = new EnemyTurn(this);
    states[(int)BattleState.Win]         = new WinState(this);
    states[(int)BattleState.Loss]        = new LossState(this);
    states[(int)BattleState.EnemyRun]    = new EnemyRunState(this);
}

private void Start()
{
    curState = BattleState.PlayerTurn;              // 전투 시작 알림
    states[(int)curState].Enter();
}

private void Update()
{
    states[(int)curState].Update();                 // 현재상태 업데이트
}

public void ChangeState(BattleState battleState)
{
    states[(int)curState].Exit();
    curState = battleState;
    states[(int)curState].Enter();
}
}
public class PlayerTurn : BaseState
{
public PlayerTurn(BattleFSM bFSM)
{
    this.bFSM = bFSM;
}
public override void Enter()
{
    // 전투 시작 케릭터와 적 등장 씬, 애니메니션 등 효과 넣기(자유)
    // 처음은 플레이어 선제
    Debug.Log("플레이어 턴");
    GameManager.Event.AddListener(EventType.PlayerActionEnd, this);           // 턴종료 받기
    GameManager.Event.AddListener(EventType.EnemyDied, this);               // 적 처치 받기
}
    public override void Update() { }
    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        string result = string.Format("받은 이벤트 종류 :  {0}, 이벤트 전달한 오브젝트 : {1}", eventType, Sender.gameObject.name.ToString());
        Debug.Log(result);
        if (eventType == EventType.PlayerActionEnd)                           // PlayerState가 Idel상태일경우
        {
            bFSM.ChangeState(BattleState.EnemyTurn);                        // 적 턴으로 변경
            GameManager.Event.RemoveEvent(EventType.PlayerActionEnd);
        }
        if (eventType == EventType.EnemyDied)                               // 적이 죽었을경우
        {
            bFSM.ChangeState(BattleState.Win);                              // 전투 승리
        }
    }

    public override void Exit()
    {
    // 턴 넘기기
    Debug.Log("턴넘김");
    }
}

public class EnemyTurn : BaseState
{
public EnemyTurn(BattleFSM bFSM)
{
    this.bFSM = bFSM;
}
public override void Enter()
    {
        GameManager.Event.AddListener(EventType.EnemyTurnEnd, this);
        Debug.Log("몬스터턴");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("턴넘김");
    }

public override void OnEvent(EventType eventType, Component Sender, object Param = null)
{
        if (eventType == EventType.EnemyTurnEnd)                           // PlayerState가 Idel상태일경우
        {
            bFSM.ChangeState(BattleState.PlayerTurn);                        // 적 턴으로 변경
            GameManager.Event.RemoveEvent(EventType.EnemyTurnEnd);
        }
        if (eventType == EventType.PlayerDied)                               // 적이 죽었을경우
        {
            bFSM.ChangeState(BattleState.Loss);                              // 전투 승리
        }
    }
}

public class WinState : BaseState
{
    public WinState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("플레이어 승리");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("전투종료");
    }

public override void OnEvent(EventType eventType, Component Sender, object Param = null)
{
}
}
public class LossState : BaseState
{
    public LossState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("플레이어 패배");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("전투종료");
    }

public override void OnEvent(EventType eventType, Component Sender, object Param = null)
{
}
}

public class EnemyRunState : BaseState
{
    public EnemyRunState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("몬스터 도주");
    }
    public override void Update() { }

    public override void Exit()
    {
        Debug.Log("전투종료");
    }

public override void OnEvent(EventType eventType, Component Sender, object Param = null)
{
}
}



