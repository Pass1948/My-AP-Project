using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInGameUI : MonoBehaviour
{
    private void Awake()
    {
        GameManager.UI.ShowInGameUI<InGameUI>("UI/SelectBoxUi");
    }
}
