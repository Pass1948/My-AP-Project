using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandable
{
    public void Execute();
    public void Undo();
}
