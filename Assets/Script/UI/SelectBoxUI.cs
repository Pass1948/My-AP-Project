using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyData;
using static PlayerData;

public class SelectBoxUI : InGameUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["AttectBoxButton"].onClick.AddListener(() => { Attack(); });
        buttons["InventoryBoxButton"].onClick.AddListener(() => { OpenWindowUI(); });
        buttons["RunBoxButton"].onClick.AddListener(() => { Run(); });
    }

    public void OpenWindowUI()
    {
        GameManager.UI.ShowWindowUI<WindowUI>("UI/InventoryWindowUI");
    }
    public void Attack()
    {
        GameManager.Event.PostNotification(EventType.Attack, this, null);
    }

    public void Run()
    {
        GameManager.Event.PostNotification(EventType.Run, this, null);
    }

}
