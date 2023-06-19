using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

public class EnemyController : Enemy
{
    private void Update()
    {
        GameManager.Event.PostNotification(EventType.ChangedEnemyHP, this, hp);
    }

    public void SetTarget(PlayerController player)
    {
        this.player = player;
        targerPoint = player.transform.position;
    }

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
        SetTarget(player);
        SetDamage(damage);
        player.TakeHit(damage);
    }

    public void TakeHit(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            dead = true;
            GameManager.Event.PostNotification(EventType.EnemyDied, this, dead);
        }
    }
}
