using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NomalTrigger : BaseScene
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Event.PostNotification(EventType.NomalMeet, this);
        Debug.Log("¡¢√ÀªÁ∞Ì");
        GameManager.Scene.BTLoadScene("BattleScene");
    }

    protected override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
