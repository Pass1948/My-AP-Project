using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectBoxUI : InGameUI, IEventListener, ICommanable
{
    protected override void Awake()
    {
        base.Awake();
        buttons["AttectBoxButton"].onClick.AddListener(() => { SelectAttack(); });
        buttons["InventoryBoxButton"].onClick.AddListener(() => { OpenWindowUI(); });
        buttons["RunBoxButton"].onClick.AddListener(() => { SelectRun(); });
    }

    private void Start()
    {
        buttons["AttectBoxButton"].Select();
        GameManager.Event.AddListener(EventType.PlayerTurn, this);
        GameManager.Event.AddListener(EventType.Close, this);
    }

    public void OpenWindowUI()
    {
        GameManager.UI.ShowWindowUI<WindowUI>("UI/InventoryWindowUI");
        GameManager.UI.ColseInGameUI(this);
    }
    public void SelectAttack()
    {
        GameManager.Event.PostNotification(EventType.SelectAttack, this);
        GameManager.UI.ColseInGameUI(this);
    }

    public void SelectRun()
    {
        GameManager.Event.PostNotification(EventType.Run, this);            // 도망 이벤트 발생
        GameManager.UI.ColseInGameUI(this);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerTurn)
        {
            buttons["AttectBoxButton"].Select();
            GameManager.UI.ShowInGameUI<InGameUI>("UI/SelectBpxUI");
        }
        if (eventType == EventType.Close)
        {
            buttons["InventoryBoxButton"].Select();
            GameManager.UI.ShowInGameUI<InGameUI>("UI/SelectBpxUI");
        }
    }

    public void Execute()
    {
        ;''
        
    }

    public void Undo()
    {
        
    }
}
