using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected PlayerController player;
    protected Vector3 targerPoint;
    protected BaseState state;

    public int hp = 5;
    public int damage = 2;
    public bool dead =false;
}
