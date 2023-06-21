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



