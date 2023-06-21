using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTurnState
{
    EnemyIdel, EnemyAttack, EnemyRun
}
public class EnemyFSM : MonoBehaviour
{
        private BaseState[] states;
        public EnemyTurnState curState;
        private void Awake()
        {
            states = new BaseState[(int)EnemyTurnState.EnemyIdel];
            states[(int)EnemyTurnState.EnemyIdel] = new EnemyIdelState(this);
            states[(int)EnemyTurnState.EnemyAttack] = new EnemyAttackState(this);
            states[(int)EnemyTurnState.EnemyRun] = new EnemyRunState(this);
        }

        private void Start()
        {
            curState = EnemyTurnState.EnemyIdel;
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
