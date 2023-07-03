using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureScene : BaseScene
{
    protected override IEnumerator LoadingRoutine()
    {
        progress = 0.5f;
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("준비완료");
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(1f);
    }
}
