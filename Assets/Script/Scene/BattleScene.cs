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
        GameManager.Pool.Recreated();
        GameManager.UI.Recreated();
        progress = 0.5f;
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("�غ�Ϸ�_BT");
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
