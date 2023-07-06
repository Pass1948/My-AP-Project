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
        buttons["TargetButton"].Select();
    }
    public void SelectTarget()
    {
        Debug.Log("타켓선택");
        GameManager.Event.PostNotification(EventType.Attack, this);         // 공격 이벤트 발생
        GameManager.Event.PostNotification(EventType.SelectTarget, this);
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PlayerButtonActUI");
        GameManager.UI.ColseInGameUI(this);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
    }
}
