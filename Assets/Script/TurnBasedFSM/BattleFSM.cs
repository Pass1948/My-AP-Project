using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static PlayerTurn;

public enum BattleState
{
 Start, PlayerTurn, PlayerAttack, PlayerRun, EnemyTurn, Win, Loss, EnemyRun, Size
}

public class BattleFSM : MonoBehaviour
{
    private GameObject playerPre;
    private GameObject EnemyPre;
    private Player playerStat;
    private Enemy enemyStat;

    private bool isDead;

    private BaseState[] states;
    public BattleState curState;
    private void Awake()
    {
        playerPre = GameManager.Resource.Load<GameObject>("Player/Battle/BattlePlayer");
        EnemyPre = GameManager.Resource.Load<GameObject>("Enemy/Enemy");

        playerStat = playerPre.GetComponent<Player>();
        enemyStat = EnemyPre.GetComponent<Enemy>();

        states = new BaseState[(int)BattleState.Size];
        states[(int)BattleState.Start]        = new BattleStartState(this);
        states[(int)BattleState.PlayerTurn]   = new PlayerTurn(this);
        states[(int)BattleState.PlayerAttack] = new PlayerAttack(this);
        states[(int)BattleState.PlayerRun]    = new PlayerRun(this);
        states[(int)BattleState.EnemyTurn]    = new EnemyTurn(this);
        states[(int)BattleState.Win]          = new WinState(this);
        states[(int)BattleState.Loss]         = new LossState(this);
        states[(int)BattleState.EnemyRun]     = new EnemyRun(this);
    }

    // 1. State Basic Area===============================
    private void Start()
    {
        curState = BattleState.Start;              // 전투 시작 알림
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


    // 2. Interaction Area===============================

    // a. Attact Zone===============================
    public void playerAT()
    {
        StartCoroutine(PlayerAttackRoutine());
    }

    IEnumerator PlayerAttackRoutine()
    {
        isDead = enemyStat.TakeDamage(playerStat.damage);
        GameManager.Event.PostNotification(EventType.PlayerAttack, this);
        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            ChangeState(BattleState.Win);
            GameManager.Event.PostNotification(EventType.PlayerAttack, this);
            yield break;
        }
        else
        {
            ChangeState(BattleState.EnemyTurn);
            yield break;
        }
    }
}



