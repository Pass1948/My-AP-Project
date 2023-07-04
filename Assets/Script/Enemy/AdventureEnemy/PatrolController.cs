using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolController : MonoBehaviour
{
    Animator animator;
    [SerializeField] Transform[] wayPoints = null;

    private NavMeshAgent agent;
    private int count = 0;
    private float EnemySpeed = 0;

    Transform target = null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        InvokeRepeating("MoveNext", 0f, 2f);
    }
    
    public void MoveNext()
    {
        if (target == null)
        {
            if (agent.velocity == Vector3.zero)
            {
                animator.SetBool("Idel_alt", false);
                agent.SetDestination(wayPoints[count++].position);
                if (count >= wayPoints.Length)
                {
                    count = 0;
                } 
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
        animator.SetBool("SetTarget", false);
        InvokeRepeating("MoveNext", 0f, 2f);
    }

    public void Chase()
    {
        if (target != null)
        {
            animator.SetBool("SetTarget", true);
            agent.speed = 2f;
            agent.SetDestination(target.position);
        }
    }
}
