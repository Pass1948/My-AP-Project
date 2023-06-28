using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState
{
    [SerializeField] Transform[] wayPoints = null;
    private NavMeshAgent agent;
    private int count = 0;
    Transform target = null;
    public PatrolState(NomalEnemyFSM_AD neFSM_AD)
    {
        this.neFSM_AD = neFSM_AD;
    }
    public override void Enter()
    {
        neFSM_AD.InvokeRepeating("MoveNext", 0f, 2f);
    }

    public override void Update() 
    {
        neFSM_AD.FindTarget();
    }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }

    public override void Exit()
    {
        
    }


}
