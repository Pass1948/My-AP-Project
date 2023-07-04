using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.PlayerInput;
using UnityEngine.Events;
using UnityEditor;

public abstract class BaseCommand : MonoBehaviour, ICommandable
{
    protected ICommandable command;
    public abstract void Execute();

    public abstract void Undo();
}

