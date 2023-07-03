using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["BackButton"].Select();
        buttons["AgreeButton"].onClick.AddListener(() => { Debug.Log("�����ۻ��!"); });
        buttons["BackButton"].onClick.AddListener(() => { CloseButton(); });
    }

    private void CloseButton()
    {
        GameManager.Event.PostNotification(EventType.Close, this);
        this.gameObject.SetActive(false);
    }
}
