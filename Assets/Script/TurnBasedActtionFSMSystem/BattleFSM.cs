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
        states[(int)BattleState.EnemyRun]    = new EnemyRunState(this);
    }

    private void Start()
    {
        curState = BattleState.PlayerTurn;              // ���� ���� �˸�
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
public class PlayerTurn : BaseState
{
    public PlayerTurn(BattleFSM bFSM)
    {
        this.bFSM = bFSM;
    }

    public override void Enter()
    {
        // ���� ���� �ɸ��Ϳ� �� ���� ��, �ִϸ޴ϼ� �� ȿ�� �ֱ�(����)
        // ó���� �÷��̾� ����
        Debug.Log("�÷��̾� ��");
        GameManager.Event.AddListener(EventType.PlayerTurnEnd, this);
        GameManager.Event.AddListener(EventType.EnemyDied, this);
    }

    public override void Exit()
    {
        // �� �ѱ��
        Debug.Log("�ϳѱ�");
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        string result = string.Format("���� �̺�Ʈ ���� :  {0}, �̺�Ʈ ������ ������Ʈ : {1}", eventType, Sender.gameObject.name.ToString());
        Debug.Log(result);
        if (eventType == EventType.PlayerTurnEnd)
        {
            bFSM.ChangeState(BattleState.EnemyTurn);
        }
        if (eventType == EventType.EnemyDied)
            {
            bFSM.ChangeState(BattleState.Win);
        }
    }

    public override void Update()
    {
    }
}

    public class EnemyTurn : BaseState
    {
        public EnemyTurn(BattleFSM bFSM)
        {
            this.bFSM = bFSM;
        }

        public override void Enter()
        {
            Debug.Log("������");
        }

        public override void Exit()
        {
            Debug.Log("�ϳѱ�");
        }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
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

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }

    public  override void Update()
        {
            // �������� 
        }
    }
    public class LossState : BaseState
    {
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

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }

    public override void Update()
        {
            // �������� 
        }
    }

    public class EnemyRunState : BaseState
    {
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

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }

    public override void Update()
        {
            // �������� 
        }
    }



