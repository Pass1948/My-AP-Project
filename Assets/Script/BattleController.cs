using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class BattleController : MonoBehaviour
{
   private AttackEnemyCommand attackCommand;

    private void Start()
    {
        attackCommand = GetComponent<AttackEnemyCommand>();
        if (attackCommand == null)
        {
            attackCommand = gameObject.AddComponent<AttackEnemyCommand>();
        }
    }
    public void OnSelect(InputValue value)
    {
        attackCommand.Execute();
    }
}
