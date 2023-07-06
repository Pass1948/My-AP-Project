using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInvenUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["BackButton"].Select();
        buttons["AgreeButton"].onClick.AddListener(() => { Debug.Log("아이템사용!"); });
        buttons["BackButton"].onClick.AddListener(() => { CloseButton(); });
    }

    private void CloseButton()
    {
        GameManager.Event.PostNotification(EventType.Close, this);
        GameManager.UI.ClosePopUpUI();
    }
}
