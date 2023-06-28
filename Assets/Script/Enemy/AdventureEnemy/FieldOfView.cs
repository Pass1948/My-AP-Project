using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    public PatrolController patrol;

    [SerializeField] float range;
    [SerializeField, Range(0f, 360f)] float angle;

    private LayerMask targetMask;
    private LayerMask obstacleMask;

    private float cosResult;

    private void Awake()
    {
        cosResult = Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad);
        targetMask = 1 << LayerMask.NameToLayer("Player");
        obstacleMask = 1 << LayerMask.NameToLayer("Defaullt");
    }
   
    private void Update()
    {
        FindTarget();
    }

    public void FindTarget()
    {
        // 1. 범위 안에 있는지
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, targetMask);
        foreach (Collider collider in colliders)
        {
            // 2. 각도 안에 있는지
            Vector3 dirTarget = (collider.transform.position - transform.position).normalized;
            Debug.Log($"Dot P{Vector3.Dot(transform.forward, dirTarget)}");
            Debug.Log(cosResult); 
            if (Vector3.Dot(transform.forward, dirTarget) < cosResult)      // .Dot = 내적계산 명령어
            {
                patrol.RemoveTarget();
            }
            else
            {
                patrol.SetTarget(collider.transform);
                patrol.Chase();
            }
                

            // 3. 중간에 장애물 확인
            float distToTarget = Vector3.Distance(transform.position, collider.transform.position);
            if (Physics.Raycast(transform.position, dirTarget, distToTarget, obstacleMask))
                continue;

            Debug.DrawRay(transform.position, dirTarget * distToTarget, Color.red);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

        Vector3 rightDir = AngleToDir(transform.eulerAngles.y + angle * 0.5f);
        Vector3 leftDir = AngleToDir(transform.eulerAngles.y - angle * 0.5f);

        Debug.DrawRay(transform.position, rightDir * range, Color.yellow);
        Debug.DrawRay(transform.position, leftDir * range, Color.yellow);
    }

    private Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
    }
}
