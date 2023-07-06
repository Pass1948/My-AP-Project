using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSelectUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["BackButton"].Select();
        buttons["AgreeButton"].onClick.AddListener(() => { AgreeButton(); });
        buttons["BackButton"].onClick.AddListener(() => { CloseButton(); });
    }

    private void AgreeButton()
    {
        GameManager.Event.PostNotification(EventType.ADin, this);
        GameManager.UI.ClosePopUpUI();
    }

    private void CloseButton()
    {
        GameManager.Event.PostNotification(EventType.Close, this);
        GameManager.UI.ClosePopUpUI();
    }

}
