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
        buttons["CloseButton"].onClick.AddListener(() => { CloseInventory(); });
    }
    private void Start()
    {
        buttons["No1.Button"].Select();
    }

    public void OpenPopUpUI()
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/CloseInvenUI");
    }

    public void CloseInventory()
    {
        GameManager.UI.ShowInGameUI<InGameUI>("UI/SelectBoxUI");
        GameManager.UI.CloseWindowUI(this);
    }
}
