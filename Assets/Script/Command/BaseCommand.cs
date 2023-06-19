using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static EnemyData;
using static PlayerData;
using static UnityEngine.InputSystem.PlayerInput;
using UnityEngine.Events;

public abstract class BaseCommand : MonoBehaviour, ICommand
{
    protected ICommand command;
    protected QTESystem QTESystem;
    public virtual void Execute(){}
}

