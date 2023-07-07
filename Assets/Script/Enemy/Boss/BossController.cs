using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IEventListener
{
    private GameObject spawnPoint;
    private GameObject AttackPosition;
    private float Speed = 5f;

    private bool isSliding = false;

    private void Awake()
    {
        AttackPosition = GameManager.Resource.Load<GameObject>("Enemy/EnemyAttackPoint");
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/EnemySpawn");
        GameManager.Event.AddListener(EventType.BossActack, this);
    }

    private void Update()
    {
        if (!isSliding)
            return;
        else
        {
            StartCoroutine(MovingRoutine());
        }
    }
    public void TatgetInMoving()
    {
        transform.position += (AttackPosition.transform.position - GetPosition()) * Speed * Time.deltaTime;
        float reachedDistance = 0.5f;
        if (Vector3.Distance(GetPosition(), AttackPosition.transform.position) < reachedDistance)
        {
            transform.position = AttackPosition.transform.position;
        }
    }

    public void ReturnPosition()
    {
        transform.position += (spawnPoint.transform.position - GetPosition()) * Speed * Time.deltaTime;
        float reachedDistance = 0.5f;
        if (Vector3.Distance(GetPosition(), spawnPoint.transform.position) < reachedDistance)
        {
            transform.position = spawnPoint.transform.position;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.EnemyAttack)
        {
            isSliding = true;
        }
    }
    IEnumerator MovingRoutine()
    {
        TatgetInMoving();
        yield return new WaitForSeconds(4f);
        isSliding = false;
        ReturnPosition();
    }
}
