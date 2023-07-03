using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TargetButton : InGameUI, IEventListener
{
    protected override void Awake()
    {
        base.Awake();
        buttons["TargetButton"].onClick.AddListener(() => {SelectTarget(); });
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
        GameManager.Event.AddListener(EventType.SelectAttack, this);
    }
    public void SelectTarget()
    {
        GameManager.Event.PostNotification(EventType.Attack, this);         // 공격 이벤트 발생
        GameManager.Event.PostNotification(EventType.SelectTarget, this);
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PlayerButtonActUI");
        this.gameObject.SetActive(false);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if(eventType == EventType.SelectAttack)
        {
            GameManager.Event.RemoveEvent(EventType.SelectAttack);
            this.gameObject.SetActive(true);
            buttons["TargetButton"].Select();
        }
    }
}
