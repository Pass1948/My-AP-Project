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
using UnityEditor;

public abstract class BaseCommand : MonoBehaviour, ICommand
{
    protected PlayerController player;
    protected EnemyController enemy;
    protected ICommand command;
    public virtual void Execute(){}

    protected virtual void Awake()
    {
        player = GameManager.Resource.Instantiate<PlayerController>("Player/Player");
        enemy = GameManager.Resource.Instantiate<EnemyController>("Enemy/Enemy");
    }
}

