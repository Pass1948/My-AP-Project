using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public interface ICommand
{
    public void Execute();
    public void Undo();
}
