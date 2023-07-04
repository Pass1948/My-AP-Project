using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : BaseScene
{
    protected override IEnumerator LoadingRoutine()
    {
        GameManager.Pool.Receated();
        GameManager.UI.Recreated();
        progress = 0.5f;
        yield return new WaitForSecondsRealtime(1f);
        GameManager.UI.ShowInGameUI<SelectBoxUI>("UI/SelectBoxUI");
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("준비완료");
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(1f);
    }
}
