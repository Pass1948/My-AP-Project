using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyDate;
using static PlayerDate;

public class SelectBoxUI : InGameUI
{
    private AttackPlayerCommand attackCommand;
    private RunCommand run;
    protected override void Awake()
    {
        base.Awake();
        attackCommand = GetComponent<AttackPlayerCommand>();
        if (attackCommand == null)
        {
            attackCommand = gameObject.AddComponent<AttackPlayerCommand>();
        }
        // buttons["AttectBoxButton"].onClick.AddListener(() => { Attack(); });
        // buttons["InventoryBoxButton"].onClick.AddListener(() => { OpenWindowUI(); });
        // buttons["RunBoxButton"].onClick.AddListener(() => { Run(); });
    }

    public void OpenWindowUI()
    {
        GameManager.UI.ShowWindowUI<WindowUI>("UI/InventoryWindowUI");
    }
    public void Attack()
    {
        //attackCommand.Execute();
    }

    public void Run()
    {
        //run.Execute();
    }

}
