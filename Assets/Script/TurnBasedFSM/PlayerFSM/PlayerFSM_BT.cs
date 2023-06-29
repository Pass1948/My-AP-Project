using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum PlayerTurnState
{
    Idle, Select, Attack, Run, Size
}
public class PlayerFSM_BT : MonoBehaviour
{
    private BaseState[] states;
    public PlayerTurnState curState;
    private void Awake()
    {
        states = new BaseState[(int)PlayerTurnState.Size];
        states[(int)PlayerTurnState.Select] = new SelectState(this);
        states[(int)PlayerTurnState.Attack] = new AttackState(this);
        states[(int)PlayerTurnState.Run] = new RunState(this);
        states[(int)PlayerTurnState.Idle] = new IdleState_BT(this);
    }

    private void Start()
    {
        curState = PlayerTurnState.Select;        
        states[(int)curState].Enter();
    }

    private void Update()
    {
        states[(int)curState].Update();                 // 현재상태 업데이트
    }

    public void ChangeState(PlayerTurnState playerTurnState)
    {
        states[(int)curState].Exit();
        curState = playerTurnState;
        states[(int)curState].Enter();
    }

    public void PlayerIdel()
    {
        StartCoroutine(PlayerIdelRoutine());
    }

    IEnumerator PlayerIdelRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameManager.Event.PostNotification(EventType.PlayerTurnEnd, this);
        GameManager.Event.PostNotification(EventType.PlayerActionEnd, this);
        yield return new WaitForSecondsRealtime(0.5f);
    }
}



