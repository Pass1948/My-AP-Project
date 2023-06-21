using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTurnState
{
    enemyIdel, enemyAttack, enemyRun
}
public class EnemyFSM : MonoBehaviour
{
        private BaseState[] states;
        public EnemyTurnState curState;
        private void Awake()
        {
            states = new BaseState[(int)EnemyTurnState.enemyIdel];
            states[(int)EnemyTurnState.enemyIdel] = new EnemyIdelState(this);
            states[(int)EnemyTurnState.enemyAttack] = new EnemyAttackState(this);
            states[(int)EnemyTurnState.enemyRun] = new EnemyRunState(this);
        }

        private void Start()
        {
            curState = EnemyTurnState.enemyIdel;
            states[(int)curState].Enter();
        }

        private void Update()
        {
            states[(int)curState].Update();                 
        }

        public void ChangeState(EnemyTurnState enemyTurnState)
        {
            states[(int)curState].Exit();
            curState = enemyTurnState;
            states[(int)curState].Enter();
        }
}
