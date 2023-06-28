using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneTriger : BaseScene
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            GameManager.Event.PostNotification(EventType.EnemyMeeting, this);
            Debug.Log("¡¢√ÀªÁ∞Ì");
            GameManager.Scene.LoadScene("BattleScene");
        }
    }

    protected override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
