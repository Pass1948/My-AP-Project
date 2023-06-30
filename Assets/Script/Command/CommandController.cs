using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CommandController : BaseCommand
{
    public void OnSelect(InputValue value) 
    {
        GameManager.Command.AddCommand(command);
    }

    public void OnCancel(InputValue value)
    {
        Undo();
    }

    public override void Execute()
    {
        GameManager.Command.UseCommand();
        GameManager.Command.RefreshCommand();
    }

    public override void Undo() 
    {
        GameManager.Command.CencelCommand(command);
    }
}
