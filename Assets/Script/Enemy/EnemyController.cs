using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

public class EnemyController : Enemy
{
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetHP(int hp)
    {
        this.hp = hp;
    }

    public void Attack(PlayerController player)
    {
        Debug.Log("너 공격된거야");
        GameManager.Event.PostNotification(EventType.Attack, this);
        SetDamage(damage);
        player.TakeHit(damage);
        GameManager.Event.PostNotification(EventType.Attack, this, null);
    }

    public void TakeHit(int damage)
    {
        SetHP(hp -= damage);
        GameManager.Event.PostNotification(EventType.ChangedEnemyHP, this, hp);
        if (hp <= 0)
        {
            dead = true;
            GameManager.Event.PostNotification(EventType.EnemyDied, this, dead);
        }
    }
}
