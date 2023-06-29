using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneTrigger : BaseScene
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("¡¢√ÀªÁ∞Ì");
            GameManager.Scene.BTLoadScene("BattleScene");
        }
    }

    protected override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
