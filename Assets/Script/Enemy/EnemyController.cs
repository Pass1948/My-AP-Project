using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

public class EnemyController : Enemy
{
    protected PlayerController player;
    protected GameObject spawnPoint;
    protected GameObject AttackPosition;
    [SerializeField] public int hp;
    [SerializeField] public int damage;
    [SerializeField] public float Speed;
    public bool dead = false;
    private bool isSliding = false;
    
    private void Awake()
    {
        player = new PlayerController();
        AttackPosition = GameManager.Resource.Load<GameObject>("Enemy/EnemyAttackPoint");
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/EnemySpawn");
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
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void Attack()
    {
        Debug.Log("너 공격된거야");
        SetDamage(damage);
        player.TakeHit(damage);
    }

    public void SetHP(int hp)
    {
        this.hp = hp;
    }

    public void TakeHit(int damage)
    {
        SetHP(hp -= damage);
        Debug.Log($"{this.hp}현재 hp");
        GameManager.Event.PostNotification(EventType.ChangedEnemyHP, this, hp);
        if (hp <= 0)
        {
            dead = true;
            GameManager.Event.PostNotification(EventType.EnemyDied, this, dead);
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

    IEnumerator MovingRoutine()
    {
        TatgetInMoving();
        yield return new WaitForSeconds(4f);
        isSliding = false;
        ReturnPosition();
    }
}
