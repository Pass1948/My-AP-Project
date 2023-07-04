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
            Debug.Log("접촉사고");
            GameManager.Scene.BTLoadScene("BattleScene");
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            Debug.Log("보스전 시작");
            
        }
    }

    protected override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
