using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected EnemyController enemy;
    protected Vector3 targerPoint;
    protected BaseState state;
    protected AttackEnemyCommand attackCommand;

    public int hp = 5;
    public int damage = 2;
    public bool dead = false;

}
