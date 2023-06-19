using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWindowUI : WindowUI
{
    protected override void Awake()
    {
        base.Awake();
        GameManager.UI.SelectWindowUI(this); 
        buttons["No1.Button"].onClick.AddListener(() => { OpenPopUpUI(); });
        buttons["CloseButton"].onClick.AddListener(() => { GameManager.UI.CloseWindowUI(this); });
    }

    public void OpenPopUpUI()
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/SelectPopUpUI");
    }
}
