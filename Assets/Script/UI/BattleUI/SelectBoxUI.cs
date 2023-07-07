using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectBoxUI : WindowUI, IEventListener
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
        Debug.Log("공격선택");
        GameManager.UI.ShowWindowUI<TargetSetUI>("UI/TargetSetUI");
        GameManager.UI.CloseWindowUI(this);
    }
    public void OpenInventory()
    {
        GameManager.UI.ShowWindowUI<WindowUI>("UI/InventoryWindowUI");
        GameManager.UI.CloseWindowUI(this);
    }

    public void SelectRun()
    {
        GameManager.Event.PostNotification(EventType.Run, this);            // 도망 이벤트 발생
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/RunSelectUI");
        GameManager.UI.CloseWindowUI(this);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerTurn)
        {
            GameManager.UI.ShowWindowUI<SelectBoxUI>("UI/SelectBoxUI");
            buttons["AttectBoxButton"].Select();
            GameManager.Event.RemoveEvent(EventType.PlayerTurn);

        }
        if (eventType == EventType.Close)
        {
            GameManager.UI.ShowWindowUI<SelectBoxUI>("UI/SelectBoxUI");
            buttons["AttectBoxButton"].Select();
            GameManager.Event.RemoveEvent(EventType.Close);
        }
    }
}
