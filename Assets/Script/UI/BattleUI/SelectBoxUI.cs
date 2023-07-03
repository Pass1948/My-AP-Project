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
        this.gameObject.SetActive(true);
        GameManager.Event.AddListener(EventType.PlayerTurn, this);
        GameManager.Event.AddListener(EventType.Close, this);
        buttons["AttectBoxButton"].Select();
    }

    public void SelectAttack()
    {
        GameManager.Event.PostNotification(EventType.SelectAttack, this);
        this.gameObject.SetActive(false);
    }
    public void OpenInventory()
    {
        GameManager.UI.ShowWindowUI<WindowUI>("UI/InventoryWindowUI");
        this.gameObject.SetActive(false);
    }

    public void SelectRun()
    {
        GameManager.Event.PostNotification(EventType.Run, this);            // 도망 이벤트 발생
        this.gameObject.SetActive(false);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PlayerTurn)
        {
            this.gameObject.SetActive(true);
        }
        if (eventType == EventType.Close)
        {
            this.gameObject.SetActive(true);
        }
    }
}
