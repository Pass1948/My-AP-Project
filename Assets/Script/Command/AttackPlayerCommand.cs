using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackPlayerCommand : BaseCommand
{
    public override void Execute()
    {
        Debug.Log("¿¿æ÷");
        player.Attack(enemy);
        GameManager.Command.AddCommand(command);
    }
}
