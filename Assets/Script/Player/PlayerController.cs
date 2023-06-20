using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
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
        GameManager.Event.PostNotification(EventType.Attack, this);
        Debug.Log("너 공격된거야");
        SetDamage(damage);
        enemy.TakeHit(damage);
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
}
