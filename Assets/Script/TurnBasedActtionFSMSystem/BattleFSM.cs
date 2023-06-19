using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    PlayerTurn, EnemyTurn, Win, Loss, EnemyRun, Size
}

public class BattleFSM : MonoBehaviour
{
    
    private StateBase[] states;
    public BattleState curState;
    private void Awake()
    {
        states = new StateBase[(int)BattleState.Size];
        states[(int)BattleState.PlayerTurn]  = new PlayerTurn(this);
        states[(int)BattleState.EnemyTurn]   = new EnemeyTurn(this);
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
public class PlayerTurn : StateBase
{
    protected BattleFSM bFSM;
    
    public PlayerTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public void Enter()
    {
        // ���� ���� �ɸ��Ϳ� �� ���� ��, �ִϸ޴ϼ� �� ȿ�� �ֱ�(����)
        // ó���� �÷��̾� ����
        Debug.Log("�÷��̾� ��");
    }

    public void Exit()
    {
        // �� �ѱ��
        Debug.Log("�ϳѱ�");
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
    }

public class EnemeyTurn : StateBase
{
    protected BattleFSM bFSM;
    public EnemeyTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public  void Enter()
    {
        Debug.Log("������");
        qTESystem.EnemyTurnAction();
    }

    public  void Exit()
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

public class WinState : StateBase
{
    private BattleFSM bFSM;
    public WinState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public  void Enter()
    {
        Debug.Log("�÷��̾� �¸�");
    }

    public  void Exit()
    {
        Debug.Log("��������");
    }

    public override void Update()
    {
        // �������� 
    }
}
public class LossState : StateBase
{
    private BattleFSM bFSM;
    public LossState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public  void Enter()
    {
        Debug.Log("�÷��̾� �й�");
    }

    public  void Exit()
    {
        Debug.Log("��������");
    }

    public override void Update()
    {
        // �������� 
    }
}

public class EnemyRunState : StateBase
{
    private BattleFSM bFSM;
    public EnemyRunState(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public  void Enter()
    {
        Debug.Log("���� ����");
    }

    public  void Exit()
    {
        Debug.Log("��������");
    }

    public override void Update()
    {
        // �������� 
    }
}

