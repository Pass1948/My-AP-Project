using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtonUI : MonoBehaviour
{
    public void OnGameStart()
    {
        GameManager.Scene.GameLoadScene("AdventureScene");
    }
}
