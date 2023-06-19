using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackPlayerCommand : BaseCommand
{
    public override void Execute()
    {
        Debug.Log("¿¿æ÷");
        GameManager.Command.AddCommand(command);
        GameManager.Event.PostNotification(EventType.EventIn, this, null);
    }
}
