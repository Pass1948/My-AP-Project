using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolController : MonoBehaviour
{

    [SerializeField] Transform[] wayPoints = null;

    private NavMeshAgent agent;
    private int count = 0;

    Transform target = null;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        InvokeRepeating("MoveNext", 0f, 2f);
    }

    private void Update(){}

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
}
