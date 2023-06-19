using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTurnState
{
    playerIdel, enemyIdel, playerBattle, enemyPatrol, enemyChase, enemyLookout
}
public class EnemyState : EnemeyTurn
{
    public EnemyState(BattleFSM bFSM) : base(bFSM)
    {
        this.bFSM = bFSM;
    }
}
