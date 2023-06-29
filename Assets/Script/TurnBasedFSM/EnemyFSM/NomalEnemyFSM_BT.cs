using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NomalEnemyTurnState_BT
{
    EnemyIdle, EnemyAttack, EnemyRun,EnemyDead, size
}
public class NomalEnemyFSM_BT : MonoBehaviour
{
        private BaseState[] states;
        public NomalEnemyTurnState_BT curState;
        private void Awake()
        {
            states = new BaseState[(int)NomalEnemyTurnState_BT.size];
            states[(int)NomalEnemyTurnState_BT.EnemyIdle] = new EnemyIdelState(this);
            states[(int)NomalEnemyTurnState_BT.EnemyAttack] = new EnemyAttackState(this);
            states[(int)NomalEnemyTurnState_BT.EnemyRun] = new EnemyRunState(this);
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
}
