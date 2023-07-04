using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectBoxUI : InGameUI, IEventListener
{
    protected override void Awake()
    {
        base.Awake();
        buttons["AttectBoxButton"].onClick.AddListener(() => { SelectAttack(); });
        buttons["InventoryBoxButton"].onClick.AddListener(() => { OpenInventory(); });
        buttons["RunBoxButton"].onClick.AddListener(() => { SelectRun(); });
    }
    
    private void Start()
    {
        GameManager.Event.AddListener(EventType.PlayerTurn, this);
        GameManager.Event.AddListener(EventType.Close, this);
        buttons["AttectBoxButton"].Select();

    }

    public void SelectAttack()
    {
        GameManager.UI.ShowInGameUI<InGameUI>("UI/TargetSetUI");
        GameManager.Event.PostNotification(EventType.SelectAttack, this);
        GameManager.UI.ColseInGameUI(this);
    }
    public void OpenInventory()
    {
        GameManager.UI.ShowWindowUI<WindowUI>("UI/InventoryWindowUI");
        GameManager.UI.ColseInGameUI(this);
    }

    public void SelectRun()
    {
        GameManager.Event.PostNotification(EventType.Run, this);            // ���� �̺�Ʈ �߻�
        GameManager.UI.ColseInGameUI(this);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerTurn)
        {
            GameManager.Event.RemoveEvent(EventType.PlayerTurn);
            GameManager.UI.ShowInGameUI<SelectBoxUI>("UI/SelectBoxUI");
            buttons["AttectBoxButton"].Select();

        }
        if (eventType == EventType.Close)
        {
            GameManager.Event.RemoveEvent(EventType.Close);
            GameManager.UI.ShowInGameUI<SelectBoxUI>("UI/SelectBoxUI");
            buttons["AttectBoxButton"].Select();
        }
    }
}
