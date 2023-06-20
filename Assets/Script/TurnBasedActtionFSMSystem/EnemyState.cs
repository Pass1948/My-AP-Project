using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTurnState
{
    enemyIdel, enemyAttack, enemyRun
}
public class EnemyState : MonoBehaviour
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
    
    public class EnemyIdelState : BaseState
    {
        public EnemyIdelState(EnemyState eFSM)
        {
            this.eFSM = eFSM;
        }
        public override void Enter()
        {
            GameManager.Event.AddListener(EventType.PlayerTurnEnd, this);   
        }

        public override void Update() { }

        public override void OnEvent(EventType eventType, Component Sender, object Param = null)
        {
            if(eventType == EventType.PlayerTurnEnd)
            {
                eFSM.ChangeState(EnemyTurnState.enemyAttack);
            }
        }

        public override void Exit()
        {
            GameManager.Event.RemoveEvent(EventType.PlayerTurnEnd);
            Debug.Log("적 움직임");
        }
    }

    public class EnemyAttackState : BaseState
    {
        public EnemyAttackState(EnemyState pFSM)
        {
            this.eFSM = pFSM;
        }
        public override void Enter()
        {
            Debug.Log("적 버튼액션시작");
        }
        public override void Update()
        {
            // 버튼액션 
            eFSM.ChangeState(EnemyTurnState.enemyIdel);
        }

        public override void Exit()
        {
            GameManager.Event.PostNotification(EventType.EnemyActionEnd, eFSM);
            GameManager.Event.PostNotification(EventType.EnemyTurnEnd, eFSM);
        }

        public override void OnEvent(EventType eventType, Component Sender, object Param = null) { }


    }

    public class EnemyRunState : BaseState
    {
        public EnemyRunState(EnemyState pFSM)
        {
            this.eFSM = pFSM;
        }
        public override void Enter()
        {
            
        }

        public override void Exit()
        {
           
        }

        public override void OnEvent(EventType eventType, Component Sender, object Param = null)
        {

        }
        public override void Update() { }
    }
}
