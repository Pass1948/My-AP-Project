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
        buttons["InventoryBoxButton"].onClick.AddListener(() => { OpenWindowUI(); });
        buttons["RunBoxButton"].onClick.AddListener(() => { SelectRun(); });
    }

    private void Start()
    {
        GameManager.Event.AddListener(EventType.PlayerTurn, this);
    }

    public void OpenWindowUI()
    {
        GameManager.UI.ShowWindowUI<WindowUI>("UI/InventoryWindowUI");
    }
    public void SelectAttack()
    {
        GameManager.Event.PostNotification(EventType.SelectAttack, this);
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
            GameManager.Event.RemoveEvent(EventType.PlayerTurn);
            this.gameObject.SetActive(true);
        }
    }
}
