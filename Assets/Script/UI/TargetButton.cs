using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetButton : InGameUI, IEventListener
{
    private bool action = false;
    protected override void Awake()
    {
        base.Awake();
        buttons["TargetButton"].onClick.AddListener(() => { if(action == true) SelectTarget(); });
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
            action = true;
            this.gameObject.SetActive(true);
        }
    }
}
