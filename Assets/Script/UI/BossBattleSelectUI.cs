using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleSelectUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
        Time.timeScale = 0;
        buttons["ApplyButton"].Select();
        buttons["ApplyButton"].onClick.AddListener(() => { StartBossBattle(); });
        buttons["CancelButton"].onClick.AddListener(() => { CloseButton(); });
    }

    private void StartBossBattle()
    {
        GameManager.Event.PostNotification(EventType.BossMeet, this);
        GameManager.UI.ClosePopUpUI();
    }

    private void CloseButton()
    {
        GameManager.UI.ClosePopUpUI();
        Time.timeScale = 1;
    }



}
