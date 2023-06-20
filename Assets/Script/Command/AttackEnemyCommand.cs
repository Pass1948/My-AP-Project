using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyCommand : BaseCommand
{
    public override void Execute()
    {
        player.Attack(enemy);
        GameManager.Command.AddCommand(command);
    }
}
