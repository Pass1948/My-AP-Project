using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IEventListener
{
    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case (EventType.BossMeet):
                GameManager.Event.RemoveEvent(EventType.BossMeet);
                StartCoroutine(BossSpawnerRoutine());
                break;
            case (EventType.NomalMeet):
                GameManager.Event.RemoveEvent(EventType.NomalMeet);
                StartCoroutine(NomalSpawnerRoutine());
                break;
            case (EventType.ADin):
                GameManager.Event.RemoveEvent(EventType.ADin);
                StartCoroutine(ADInRoutine());
                break;
        }
    }

    void Start()
    {
        GameManager.Event.AddListener(EventType.BossMeet, this);
        GameManager.Event.AddListener(EventType.NomalMeet, this);
        GameManager.Event.AddListener(EventType.ADin, this);
    }
    
    IEnumerator BossSpawnerRoutine()
    {
        GameManager.Event.PostNotification(EventType.BTin, this);
        yield return new WaitForSecondsRealtime(5f);
        GameManager.Event.PostNotification(EventType.Boss, this);
        yield return new WaitForSecondsRealtime(0.5f);
    }
    IEnumerator NomalSpawnerRoutine()
    {
        GameManager.Event.PostNotification(EventType.BTin, this);
        yield return new WaitForSecondsRealtime(5f);
        GameManager.Event.PostNotification(EventType.Nomal, this);
        yield return new WaitForSecondsRealtime(0.5f);
    }

    IEnumerator ADInRoutine()
    {
        GameManager.Event.PostNotification(EventType.ADin, this);
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
