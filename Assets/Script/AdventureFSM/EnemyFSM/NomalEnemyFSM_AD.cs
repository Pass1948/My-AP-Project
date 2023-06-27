using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NomalEnemyState_AD
{
    Idle, Patrol, Chase, Size
}

public class NomalEnemyFSM_AD : MonoBehaviour
{
    private BaseState[] states;
    public NomalEnemyState_AD curState;
    private void Awake()
    {
        states = new BaseState[(int)PlayerTurnState.Size];
        states[(int)NomalEnemyState_AD.Idle] = new IdelState_AD(this);
        states[(int)NomalEnemyState_AD.Patrol] = new PatrolState(this);
        states[(int)NomalEnemyState_AD.Chase] = new ChaseState(this);
        
    }

    private void Start()
    {
        curState = NomalEnemyState_AD.Patrol;
        states[(int)curState].Enter();
    }

    private void Update()
    {
        states[(int)curState].Update();                 // 현재상태 업데이트
    }

    public void ChangeState(NomalEnemyState_AD ADEnemyState)
    {
        states[(int)curState].Exit();
        curState = ADEnemyState;
        states[(int)curState].Enter();
    }
}
