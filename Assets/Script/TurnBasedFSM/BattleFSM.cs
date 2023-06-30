using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using static PlayerTurn;

public enum BattleState
{
 Start, PlayerTurn, EnemyTurn, Win, Loss, Size
}

public class BattleFSM : MonoBehaviour
{
    private GameObject playerPre;
    private GameObject EnemyPre;
    private Player playerStat;
    private Enemy enemyStat;

    private BaseState[] states;
    public BattleState curState;
    private void Awake()
    {
        playerPre = GameManager.Resource.Load<GameObject>("Player/Battle/BattlePlayer");
        EnemyPre = GameManager.Resource.Load<GameObject>("Enemy/Enemy");
        playerStat = EnemyPre.GetComponent<Player>();
        enemyStat = EnemyPre.GetComponent<Enemy>();
        states = new BaseState[(int)BattleState.Size];
        states[(int)BattleState.Start]       = new BattleStartState(this);
        states[(int)BattleState.PlayerTurn]  = new PlayerTurn(this);
        states[(int)BattleState.EnemyTurn]   = new EnemyTurn(this);
        states[(int)BattleState.Win]         = new WinState(this);
        states[(int)BattleState.Loss]        = new LossState(this);
    }

    // 1. State Basic Area===============================
    private void Start()
    {
        curState = BattleState.Start;              // ���� ���� �˸�
        states[(int)curState].Enter();
    }
    
    private void Update()
    {
        states[(int)curState].Update();                 // ������� ������Ʈ
    }
    
    public void ChangeState(BattleState battleState)
    {
        states[(int)curState].Exit();
        curState = battleState;
        states[(int)curState].Enter();
    }


    // 2. Interaction Area===============================

    // a. Attact Zone===============================
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyStat.TakeDamage(playerStat.damage);
        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            EndBattle();
        }
        else
        {
            // �ϳѱ��(Enemy)
        }
    }

    IEnumerator EnemyTurnAttact()
    {
        yield return new WaitForSeconds(2f);
        bool isDead = enemyStat.TakeDamage(playerStat.damage);
        yield return new WaitForSeconds(0.5f);
        if (isDead)
        {
            EndBattle();
        }
        else
        {
            // �ϳѱ��(Player)
        }
    }

    // Win/Loss Check===============================
    public void EndBattle()
    {
        if (curState == BattleState.Win)
        {
            Debug.Log("�̱�");
        }
        else if (curState == BattleState.Loss)
        {
            Debug.Log("����");
        }
    }


}



