using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        curState = BattleState.PlayerTurn;        // 전투 시작 알림
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
public class PlayerTurn : BaseState, IEventListener
{
    private BattleFSM bFSM;
    private PlayerController controller;

    public PlayerTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        // 전투 시작 케릭터와 적 등장 씬, 애니메니션 등 효과 넣기(자유)
        // 처음은 플레이어 선제
        Debug.Log("플레이어 턴");
        GameManager.Event.PostNotification(EventType.PlayerTurn, this);
        GameManager.Event.AddListener(EventType.ChangedPlayerHP, this);
    }

    public override void Exit()
    {
        // 턴 넘기기
        Debug.Log("턴넘김");
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
            if (!enemyIsLive)    // 몬스터가 죽었다면
            {
                bFSM.ChangeState(BattleState.Win);
            }
            else            // 몬스터가 살경우
            {
                bFSM.ChangeState(BattleState.EnemyTurn);
            }
    }

public class EnemyTurn : BaseState
{
    private BattleFSM bFSM;
    public EnemyTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("몬스터턴");
        qTESystem.EnemyTurnAction();
    }

    public override void Exit()
    {
        Debug.Log("턴넘김");
    }

    public override void Update()
    {
        // 적의 체력을 체크해서 선택을 한다
        // 플레이어한테 공격을 가한다
        // 플레이어의 체력을 확인한다 

        if (!playerIsLive)   // 플레이어 체력이 0이거나 더 적을경우
        {
                bFSM.ChangeState(BattleState.Loss);
        }
        else if (playerIsLive)  // 플레이어가 살아있을경우
        {
                bFSM.ChangeState(BattleState.PlayerTurn);
        }
    }
}

public class WinState : BaseState
{
    private BattleFSM bFSM;
    public WinState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("플레이어 승리");
    }

    public override void Exit()
    {
        Debug.Log("전투종료");
    }

    public override void Update()
    {
        // 게임종료 
    }
}
public class LossState : BaseState
{
    private BattleFSM bFSM;
    public LossState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("플레이어 패배");
    }

    public override void Exit()
    {
        Debug.Log("전투종료");
    }

    public override void Update()
    {
        // 게임종료 
    }
}

public class EnemyRunState : BaseState
{
    private BattleFSM bFSM;
    public EnemyRunState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("몬스터 도주");
    }

    public override void Exit()
    {
        Debug.Log("전투종료");
    }

    public override void Update()
    {
        // 게임종료 
    }
}

