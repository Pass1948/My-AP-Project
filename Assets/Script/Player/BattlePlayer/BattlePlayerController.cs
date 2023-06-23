using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour, IEventListener
{
    private GameObject spawnPoint;
    private GameObject AttackPosition;

    private int damage;   
    private int hp;

    private float Speed;

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

    public void SetDamage(int damage)       // 무기 혹은 아이템을 사용할경우 상승효과를 구현해야함
    {
        this.damage = damage;
    }

    public void Attack()
    {
        Debug.Log("너 공격된거야");
        SetDamage(damage);
        //enemy.TakeHit(damage);
    }
    public void SetHP(int hp)
    {
        this.hp = hp;
    }

    public void TakeHit(int damage)
    {
        SetHP(hp -= damage);
        GameManager.Event.PostNotification(EventType.ChangedPlayerHP, this);
        if (hp <= 0)
        {
            GameManager.Event.PostNotification(EventType.PlayerDied, this);
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
