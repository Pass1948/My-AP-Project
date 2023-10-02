using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTirgger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("º¸½ºÀü");
        GameManager.save.Save();
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossBattleSelectUI");
    }
}
