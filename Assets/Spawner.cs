using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour, IEventListener
{
    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case (EventType.BossMeet):
                StartCoroutine(BossSpawnerRoutine());
                break;
            case (EventType.NomalMeet):
                StartCoroutine(NomalSpawnerRoutine());
                break;
            case (EventType.Result):
                StartCoroutine(ADInRoutine());
                break;
        }
    }
    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneChangAdd;
    }
    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= SceneChangAdd;
    }
    private void Awake()
    {
        AddEvent();
    }

    private void AddEvent()
    {
        GameManager.Event.AddListener(EventType.BossMeet, this);
        GameManager.Event.AddListener(EventType.NomalMeet, this);
        GameManager.Event.AddListener(EventType.Result, this);
    }

    private void SceneChangAdd(Scene arg0, LoadSceneMode arg1)
    {
        StartCoroutine(AddEventRoutine());
    }

    IEnumerator AddEventRoutine()
    {
        GameManager.Event.RemoveEvent(EventType.BossMeet);
        GameManager.Event.RemoveEvent(EventType.NomalMeet);
        GameManager.Event.RemoveEvent(EventType.Result);
        yield return new WaitForSecondsRealtime(0.5f);
        AddEvent();
        yield return new WaitForSecondsRealtime(0.5f);
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
        GameManager.Event.PostNotification(EventType.Result, this);
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
