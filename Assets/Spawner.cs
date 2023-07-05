using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IEventListener
{
    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if(eventType == EventType.BossMeet)
        {
            GameManager.Event.RemoveEvent(EventType.BossMeet);
            StartCoroutine(BossSpawnerRoutine());
        }
        if (eventType == EventType.NomalMeet)
        {
            GameManager.Event.RemoveEvent(EventType.NomalMeet);
            StartCoroutine(NomalSpawnerRoutine());
        }
    }

    void Start()
    {
        GameManager.Event.AddListener(EventType.BossMeet, this);
        GameManager.Event.AddListener(EventType.NomalMeet, this);
        DontDestroyOnLoad(this);
    }

    
    IEnumerator BossSpawnerRoutine()
    {
        yield return new WaitForSecondsRealtime(5f);
        GameManager.Event.PostNotification(EventType.Boss, this);
        yield return new WaitForSecondsRealtime(0.5f);
    }
    IEnumerator NomalSpawnerRoutine()
    {
        yield return new WaitForSecondsRealtime(5f);
        GameManager.Event.PostNotification(EventType.Nomal, this);
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
