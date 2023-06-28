using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ChaseState : BaseState
{
    private float range = 3;
    private float angle = 50;
    private LayerMask targetMask;
    private LayerMask objectMask;
    private float cosResult;
    public ChaseState(NomalEnemyFSM_AD neFSM_AD)
    {
        this.neFSM_AD = neFSM_AD;
    }
    public override void Enter()
    {
        targetMask = 1 << LayerMask.NameToLayer("Player");
        targetMask = 1 << LayerMask.NameToLayer("Defaullt");

        cosResult = Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad);
    }

    public override void Update() { }

    public override void OnEvent(EventType eventType, Component Sender, object Param = null)
    {

    }

    public override void Exit()
    {

    }

    public void FindTarget()
    {
        // 1. 범위 안에 있는지
        Collider[] colliders = Physics.OverlapSphere(neFSM_AD.transform.position, range, targetMask);
        foreach (Collider collider in colliders)
        {
            // 2. 각도 안에 있는지
            Vector3 dirTarget = (collider.transform.position - neFSM_AD.transform.position).normalized;
            if (Vector3.Dot(neFSM_AD.transform.forward, dirTarget) < cosResult)      // .Dot = 내적계산 명령어
                continue;

            // 3. 중간에 장애물 확인
            float distToTarget = Vector3.Distance(neFSM_AD.transform.position, collider.transform.position);
            if (Physics.Raycast(neFSM_AD.transform.position, dirTarget, distToTarget, obstacleMask))
                continue;

            Debug.DrawRay(neFSM_AD.transform.position, dirTarget * distToTarget, Color.red);
        }
    }
}
