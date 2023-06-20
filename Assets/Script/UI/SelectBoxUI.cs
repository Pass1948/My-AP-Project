using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectBoxUI : InGameUI
{
    [SerializeField] EnemyController enemy;
    [SerializeField] PlayerController player;
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
        GameManager.Event.PostNotification(EventType.Attack, this);         // 공격 이벤트 발생
    }

    public void Run()
    {
        GameManager.Event.PostNotification(EventType.Run, this);            // 도망 이벤트 발생
    }

}
