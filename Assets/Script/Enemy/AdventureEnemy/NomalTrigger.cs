using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NomalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.save.Save();
        GameManager.Event.PostNotification(EventType.NomalMeet, this);
        Debug.Log("¡¢√ÀªÁ∞Ì");
    }
}
