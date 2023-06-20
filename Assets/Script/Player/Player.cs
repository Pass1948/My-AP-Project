using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    private EnemyController enemy;

    public int hp = 5;
    public int damage = 2;
    public bool dead = false;

    protected virtual void Awake()
    {
        enemy = GameManager.Resource.Instantiate<EnemyController>("Enemy/Enemy");
    }
}
