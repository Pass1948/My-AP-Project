using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    private void Awake()
    {
        GameManager.UI.ShowInGameUI<InGameUI>("UI/SelectBoxUi");
    }

    private void Start()
    {
        attackCommand = GetComponent<AttackEnemyCommand>();
        if (attackCommand == null)
        {
            attackCommand = gameObject.AddComponent<AttackEnemyCommand>();
        }
    }

    private void Update()
    {
        GameManager.Event.PostNotification(EventType.ChangedPlayerHP, this, hp);
    }

    public void OnSelect(InputValue value)
    {
        attackCommand.Execute();
    }

    public void SetTarget(EnemyController enemy)
    {
        this.enemy = enemy;
        targerPoint = enemy.transform.position;
    }

    public void SetDamage(int damage)       // 무기 혹은 아이템을 사용할경우 상승효과를 구현해야함
    {
        this.damage = damage;
    }

    public void SetHP(int hp)               // 방어구 혹은 버프 아이템을 쓸경우 상승효과를 구현해야함
    {
        this.hp = hp;
    }

    public void Attack(EnemyController enemy)
    {
        Debug.Log("너 공격된거야");
        SetTarget(enemy);
        SetDamage(damage);
        enemy.TakeHit(damage);
    }

    public void TakeHit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GameManager.Event.PostNotification(EventType.PlayerDied, this, dead);
        }
    }
}
