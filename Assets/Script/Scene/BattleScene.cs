using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : BaseScene
{
    protected override IEnumerator LoadingRoutine_AD()
    {
        yield return null;
    }

    protected override IEnumerator LoadingRoutine_BT()
    {
        GameManager.Scene.SceneClear();
        GameManager.Pool.Receated();
        GameManager.UI.Recreated();
        progress = 0.5f;
        yield return new WaitForSecondsRealtime(1f);
        GameManager.UI.ShowInGameUI<SelectBoxUI>("UI/SelectBoxUI");
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("준비완료_BT");
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
