using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NomalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Event.PostNotification(EventType.NomalMeet, this);
        Debug.Log("¡¢√ÀªÁ∞Ì");
    }
}
