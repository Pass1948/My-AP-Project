using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        states[(int)BattleState.EnemyRun]    = new EnemyRunState(this);
    }

    private void Start()
    {
        curState = BattleState.PlayerTurn;        // ���� ���� �˸�
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
}
public class PlayerTurn : BaseState, IEventListener
{
    private BattleFSM bFSM;
    private PlayerController controller;

    public PlayerTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        // ���� ���� �ɸ��Ϳ� �� ���� ��, �ִϸ޴ϼ� �� ȿ�� �ֱ�(����)
        // ó���� �÷��̾� ����
        Debug.Log("�÷��̾� ��");
        GameManager.Event.PostNotification(EventType.PlayerTurn, this);
        GameManager.Event.AddListener(EventType.ChangedPlayerHP, this);
    }

    public override void Exit()
    {
        // �� �ѱ��
        Debug.Log("�ϳѱ�");
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
            if (!enemyIsLive)    // ���Ͱ� �׾��ٸ�
            {
                bFSM.ChangeState(BattleState.Win);
            }
            else            // ���Ͱ� ����
            {
                bFSM.ChangeState(BattleState.EnemyTurn);
            }
    }

public class EnemyTurn : BaseState
{
    private BattleFSM bFSM;
    public EnemyTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("������");
        qTESystem.EnemyTurnAction();
    }

    public override void Exit()
    {
        Debug.Log("�ϳѱ�");
    }

    public override void Update()
    {
        // ���� ü���� üũ�ؼ� ������ �Ѵ�
        // �÷��̾����� ������ ���Ѵ�
        // �÷��̾��� ü���� Ȯ���Ѵ� 

        if (!playerIsLive)   // �÷��̾� ü���� 0�̰ų� �� �������
        {
                bFSM.ChangeState(BattleState.Loss);
        }
        else if (playerIsLive)  // �÷��̾ ����������
        {
                bFSM.ChangeState(BattleState.PlayerTurn);
        }
    }
}

public class WinState : BaseState
{
    private BattleFSM bFSM;
    public WinState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("�÷��̾� �¸�");
    }

    public override void Exit()
    {
        Debug.Log("��������");
    }

    public override void Update()
    {
        // �������� 
    }
}
public class LossState : BaseState
{
    private BattleFSM bFSM;
    public LossState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("�÷��̾� �й�");
    }

    public override void Exit()
    {
        Debug.Log("��������");
    }

    public override void Update()
    {
        // �������� 
    }
}

public class EnemyRunState : BaseState
{
    private BattleFSM bFSM;
    public EnemyRunState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        Debug.Log("���� ����");
    }

    public override void Exit()
    {
        Debug.Log("��������");
    }

    public override void Update()
    {
        // �������� 
    }
}

