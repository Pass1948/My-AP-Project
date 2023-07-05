using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTirgger : BaseScene
{
    private void OnTriggerEnter(Collider other)
    {
         GameManager.Event.PostNotification(EventType.BossMeet, this);
         Debug.Log("º¸½ºÀü");
         GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossBattleSelectUI");
    }

    protected override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
