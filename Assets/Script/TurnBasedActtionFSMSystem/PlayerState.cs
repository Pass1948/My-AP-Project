using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTurnState
{
    Idel, enemyIdel, playerBattle, enemyPatrol, enemyChase, enemyLookout
}
public class PlayerState : PlayerTurn
{
    public PlayerState(BattleFSM bFSM) : base(bFSM)
    {
        this.bFSM = bFSM;
    }




}
