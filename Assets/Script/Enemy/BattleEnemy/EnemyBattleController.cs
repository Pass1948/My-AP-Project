using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

public class EnemyBattleController : MonoBehaviour, IEventListener
{
    private BattlePlayerController player;
    private GameObject spawnPoint;
    private GameObject AttackPosition;

    private int damage = 2;
    private int hp = 5;

    private float Speed = 5f;

    private bool isSliding = false;

    private void Awake()
    {
        AttackPosition = GameManager.Resource.Load<GameObject>("Enemy/EnemyAttackPoint");
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/EnemySpawn");
        player = GameManager.Resource.Load<BattlePlayerController>("Player/Battle/BattlePlayer");
        GameManager.Event.AddListener(EventType.EnemyAttack, this);
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
        player.TakeHit(damage);
    }

    public void TakeHit(int damage)
    {
        hp -= damage;
        if (hp > 0)
        {
            Debug.Log("살았지롱~!?");
            GameManager.Event.PostNotification(EventType.EnemyisLive, this);
        }
        if (hp <= 0)
        {
            Debug.Log("적이 죽었습니다");
            GameManager.Event.PostNotification(EventType.EnemyDied, this);
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
            GameManager.Event.RemoveEvent(EventType.EnemyAttack);
        }
        if (eventType == EventType.PressButton)
        {
            Attack();
            GameManager.Event.RemoveEvent(EventType.PressButton);
            GameManager.QTE.Critical();
        }
        if (eventType == EventType.PressFail)
        {
            GameManager.Event.RemoveEvent(EventType.PressFail);
            return;
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
