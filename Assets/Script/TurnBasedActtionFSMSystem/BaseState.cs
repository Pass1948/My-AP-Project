using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BaseState : MonoBehaviour
{
    protected BattleFSM bFSM;
    protected PlayerState pFSM;
    public bool playerIsLive = false;
    public bool enemyIsLive = false;

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
