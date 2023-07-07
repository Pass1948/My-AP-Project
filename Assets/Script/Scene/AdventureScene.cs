using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdventureScene : BaseScene
{
    protected override IEnumerator LoadingRoutine_AD()
    {
        GameManager.Scene.SceneClear();
        GameManager.Pool.Recreated();
        GameManager.UI.Recreated();
        progress = 0.5f;
        yield return new WaitForSecondsRealtime(0.5f);
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("준비완료_AD");
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(0.5f);
    }

    protected override IEnumerator LoadingRoutine_BT()
    {
        yield return null;
    }
}
