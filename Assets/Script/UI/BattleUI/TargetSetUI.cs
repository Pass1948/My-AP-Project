using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetSetUI : InGameUI, IEventListener
{
    protected override void Awake()
    {
        base.Awake();
        buttons["TargetButton"].onClick.AddListener(() => {SelectTarget(); });
        
    }
    private void Start()
    {
        GameManager.Event.AddListener(EventType.SelectAttack, this);
        buttons["TargetButton"].Select();
    }
    public void SelectTarget()
    {
        GameManager.Event.PostNotification(EventType.Attack, this);         // ���� �̺�Ʈ �߻�
        GameManager.Event.PostNotification(EventType.SelectTarget, this);
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PlayerButtonActUI");
        GameManager.UI.ColseInGameUI(this);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.SelectAttack)
        {
            GameManager.Event.RemoveEvent(EventType.SelectAttack);
            buttons["TargetButton"].Select();
        }
    }
}
