using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BaseState : MonoBehaviour
{
    protected AttackPlayerCommand attack;
    protected QTESystem qTESystem;
    public bool playerIsLive;
    public bool enemyIsLive;

    public abstract void Enter();
    public abstract void Update();

    public abstract void Exit();
}
