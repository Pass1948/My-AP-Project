using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour, IEventListener
{
    private GameObject spawnPoint;
    private GameObject AttackPosition;
    private EnemyBattleController enemy;

    private int damage = 2;   
    private int hp = 5;

    private float Speed = 5f;

    private bool isSliding = false;

    private void Awake()
    {
        AttackPosition = GameManager.Resource.Load<GameObject>("Player/Battle/PlayerAttackPoint");
        spawnPoint = GameManager.Resource.Load<GameObject>("Player/Battle/PlayerSpawn");
        enemy = GameManager.Resource.Load<EnemyBattleController>("Enemy/Enemy");
        GameManager.Event.AddListener(EventType.SelectTarget, this);
        GameManager.Event.AddListener(EventType.PressButton, this);
        GameManager.Event.AddListener(EventType.PressFail, this);
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
        enemy.TakeHit(damage);
    }

    public void TakeHit(int damage)
    {
        hp -= damage;
        if (hp > 0)
        {
            Debug.Log("이걸 못죽이네");
            GameManager.Event.PostNotification(EventType.PlayerisLive, this);
        }
        if (hp <= 0)
        {
            Debug.Log("아군이 당했습니다");
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
            GameManager.Event.RemoveEvent(EventType.SelectTarget);
        }
        if (eventType == EventType.PressButton)
        {
            Attack();
            GameManager.Event.RemoveEvent(EventType.PressButton);
            GameManager.QTE.Critical();
        }
        if (eventType == EventType.PressFail)
        {
            Attack();
            GameManager.Event.RemoveEvent(EventType.PressFail);
            GameManager.QTE.Attack();
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
