using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTirgger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
         Debug.Log("������");
         GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossBattleSelectUI");
    }
}
