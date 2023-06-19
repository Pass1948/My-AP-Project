using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["AgreeButton"].onClick.AddListener(() => { Debug.Log("�����ۻ��!"); });
        buttons["BackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
    }
}
