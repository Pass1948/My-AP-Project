using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    public void SetDamage(int damage)       // ���� Ȥ�� �������� ����Ұ�� ���ȿ���� �����ؾ���
    {
        this.damage = damage;
    }

    public void SetHP(int hp)               // �� Ȥ�� ���� �������� ����� ���ȿ���� �����ؾ���
    {
        this.hp = hp;
    }

    public void Attack(EnemyController enemy)
    {
        GameManager.Event.PostNotification(EventType.Attack, this);
        Debug.Log("�� ���ݵȰž�");
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
