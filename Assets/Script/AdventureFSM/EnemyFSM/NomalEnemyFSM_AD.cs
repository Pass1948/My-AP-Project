using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NomalEnemyState_AD
{
    Idle, Patrol, Chase, Size
}

public class NomalEnemyFSM_AD : MonoBehaviour
{
    //==================Chase
    [SerializeField] float range;
    [SerializeField, Range(0f, 360f)] float angle;
    private LayerMask targetMask;
    [SerializeField] LayerMask obstacleMask;
    private float cosResult;

    //==================Patroll
    [SerializeField] Transform[] wayPoints = null;
    private NavMeshAgent agent;
    private int count = 0;
    Transform target = null;

    //==================State
    private BaseState[] states;
    public NomalEnemyState_AD curState;
    private void Awake()
    {
        states = new BaseState[(int)PlayerTurnState.Size];
        states[(int)NomalEnemyState_AD.Idle] = new IdelState_AD(this);
        states[(int)NomalEnemyState_AD.Patrol] = new PatrolState(this);
        states[(int)NomalEnemyState_AD.Chase] = new ChaseState(this);

        targetMask = 1 << LayerMask.NameToLayer("Player");
        cosResult = Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad);

        agent = GetComponent<NavMeshAgent>();

        
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

    public void MoveNext()
    {
        if (target == null)
        {
            if (agent.velocity == Vector3.zero)
            {
                agent.SetDestination(wayPoints[count++].position);

                if (count >= wayPoints.Length)
                    count = 0;
            }
        }
    }

    public void SetTarget(Transform target)
    {
        CancelInvoke();
        this.target = target;
    }

    public void RemoveTarget()
    {
        target = null;
        InvokeRepeating("MoveNext", 0f, 2f);
    }

    public void Chase()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    public void FindTarget()
    {
        // 1. 범위 안에 있는지
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, targetMask.);
        foreach (Collider collider in colliders)
        {
            // 2. 각도 안에 있는지
            Vector3 dirTarget = (collider.transform.position - transform.position).normalized;
            if (Vector3.Dot(transform.forward, dirTarget) < cosResult)      // .Dot = 내적계산 명령어
                continue;

            // 3. 중간에 장애물 확인
            float distToTarget = Vector3.Distance(transform.position, collider.transform.position);
            if (Physics.Raycast(transform.position, dirTarget, distToTarget, obstacleMask))
                continue;

            Debug.DrawRay(transform.position, dirTarget * distToTarget, Color.red);
        }
    }
}
