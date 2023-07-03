using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour, IEventListener
{
    private GameObject spawnPoint;
    private GameObject AttackPosition;

    private float Speed = 5f;
    private bool isSliding = false;

    private void Awake()
    {
        AttackPosition = GameManager.Resource.Load<GameObject>("Player/Battle/PlayerAttackPoint");
        spawnPoint = GameManager.Resource.Load<GameObject>("Player/Battle/PlayerSpawn");
        
        GameManager.Event.AddListener(EventType.SelectTarget, this);
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
        if (eventType == EventType.SelectTarget)
        {
            isSliding = true;
            GameManager.Event.RemoveEvent(EventType.SelectTarget);
        }
    }

    IEnumerator MovingRoutine()
    {
        TatgetInMoving();
        yield return new WaitForSeconds(2f);
        isSliding = false;
        ReturnPosition();
    }
}
