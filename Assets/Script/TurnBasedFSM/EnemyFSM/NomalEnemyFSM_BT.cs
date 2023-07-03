using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NomalEnemyTurnState_BT
{
    EnemyIdle, EnemyAttack,EnemyDead, size
}
public class NomalEnemyFSM_BT : MonoBehaviour
{
    private GameObject playerPre;
    private GameObject EnemyPre;
    private Player playerStat;
    private Enemy enemyStat;

    private bool isDead;

    private BaseState[] states;
    public NomalEnemyTurnState_BT curState;
    
    private void Awake()
    {
    
        playerPre = GameManager.Resource.Load<GameObject>("Player/Battle/BattlePlayer");
        EnemyPre = GameManager.Resource.Load<GameObject>("Enemy/Enemy");
    
        playerStat = playerPre.GetComponent<Player>();
        enemyStat = EnemyPre.GetComponent<Enemy>();
    
        states = new BaseState[(int)NomalEnemyTurnState_BT.size];
        states[(int)NomalEnemyTurnState_BT.EnemyIdle] = new EnemyIdelState(this);
        states[(int)NomalEnemyTurnState_BT.EnemyAttack] = new EnemyAttackState(this);
        states[(int)NomalEnemyTurnState_BT.EnemyDead] = new EnemyDeadState(this);
    
    }
    
    private void Start()
    {
        curState = NomalEnemyTurnState_BT.EnemyIdle;
        states[(int)curState].Enter();
    }
    
    private void Update()
    {
        states[(int)curState].Update();                 
    }
    
    public void ChangeState(NomalEnemyTurnState_BT enemyTurnState)
    {
        states[(int)curState].Exit();
        curState = enemyTurnState;
        states[(int)curState].Enter();
    }
    
    
    public void EnemyAT()
    {
        StartCoroutine(EnemyTurnAttactRoutine());
    }

    IEnumerator EnemyTurnAttactRoutine()
    {
        yield return new WaitForSeconds(2f);
        isDead = playerStat.TakeDamage(enemyStat.damage);
        yield return new WaitForSeconds(0.5f);
        if (isDead)
        {
            GameManager.Event.PostNotification(EventType.PlayerDied, this);
            yield break;
        }
        else
        {
            GameManager.Event.PostNotification(EventType.EnemyTurnEnd, this);
            ChangeState(NomalEnemyTurnState_BT.EnemyIdle);
            yield break;
        }
    }

    public void Counter()
    {
        StartCoroutine(CounterRoutine());
    }

    public void Miss()
    {
        StartCoroutine(MissRoutine());
    }
    IEnumerator CounterRoutine()
    {
        yield return new WaitForSeconds(2f);
        isDead = enemyStat.TakeDamage(playerStat.damage);
        yield return new WaitForSeconds(0.5f);
        if (isDead)
        {
            GameManager.Event.PostNotification(EventType.EnemyDied, this);
            yield break;
        }
        else
        {
            GameManager.Event.PostNotification(EventType.EnemyTurnEnd, this);
            ChangeState(NomalEnemyTurnState_BT.EnemyIdle);
            yield break;
        }
    }

    IEnumerator MissRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Event.PostNotification(EventType.EnemyTurnEnd, this);
        yield return new WaitForSeconds(2f);
        ChangeState(NomalEnemyTurnState_BT.EnemyIdle);
        yield break;
    }

    public void EnemyRun()
    {
        StartCoroutine(EnemyRunRoutine());
    }
    IEnumerator EnemyRunRoutine()
    {
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(0.5f);
        GameManager.Event.PostNotification(EventType.EnemyRun, this);
        yield break;
    }
}
