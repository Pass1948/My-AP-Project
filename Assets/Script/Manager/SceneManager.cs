using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour, IEventListener
{
    public float progress { get; protected set; }
    private LoadingUI_BTStart loadUI_BT;
    private LoadingUI_BTEnd loadUI_AD;
    private void Awake()
    {
        LoadingUI_BTStart uiStart = Resources.Load<LoadingUI_BTStart>("UI/LoadingUI/LoadingUI_BTStart");
        loadUI_BT = Instantiate(uiStart);
        loadUI_BT.transform.SetParent(transform);

        LoadingUI_BTEnd uiEnd = Resources.Load<LoadingUI_BTEnd>("UI/LoadingUI/LoadingUI_BTEnd");
        loadUI_AD = Instantiate(uiEnd);
        loadUI_AD.transform.SetParent(transform);

        AddEvent();
    }

    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneChangAdd;
    }
    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= SceneChangAdd;
    }

    private void AddEvent()
    {
        GameManager.Event.AddListener(EventType.BTin, this);
        GameManager.Event.AddListener(EventType.ADin, this);
    }

    private void SceneChangAdd(Scene arg0, LoadSceneMode arg1)
    {
        StartCoroutine(AddEventRoutine());
    }

    IEnumerator AddEventRoutine()
    {
        GameManager.Event.RemoveEvent(EventType.ADin);
        GameManager.Event.RemoveEvent(EventType.BTin);
        yield return new WaitForSecondsRealtime(0.5f);
        AddEvent();
        yield return new WaitForSecondsRealtime(0.5f);
    }


    public void BTLoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine_BT(sceneName));
    }

    public void ADLoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine_AD(sceneName));
    }

    IEnumerator LoadingRoutine_BT(string sceneName)
    {
        Time.timeScale = 0f;
        loadUI_BT.BattleActive();
        yield return new WaitForSecondsRealtime(3.5f);
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        while (!oper.isDone)
        {
            yield return null;
        }
        LoadAsync_BT();
        yield return new WaitForSecondsRealtime(2.5f);
        while (progress < 1f)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        loadUI_BT.BattleActiveEnd();
        yield return new WaitForSecondsRealtime(0.5f);
    }

    IEnumerator LoadingRoutine_AD(string sceneName)
    {
        loadUI_AD.FadeIn();
        yield return new WaitForSecondsRealtime(1.25f);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForSecondsRealtime(1f);
        while (!oper.isDone)
        {
            yield return null;
        }
        LoadAsync_AD();
        yield return new WaitForSecondsRealtime(2.5f);
        while (progress < 1f)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        Debug.Log("로딩 종료");
        loadUI_AD.FadeOut();
        GameManager.save.Load();
        yield return new WaitForSecondsRealtime(0.5f);
    }

    public void GameLoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine_Play(sceneName));
    }

    IEnumerator LoadingRoutine_Play(string sceneName)
    {
        loadUI_AD.FadeIn();
        yield return new WaitForSecondsRealtime(1.25f);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForSecondsRealtime(1f);
        while (!oper.isDone)
        {
            yield return null;
        }
        LoadAsync_AD();
        yield return new WaitForSecondsRealtime(2.5f);
        while (progress < 1f)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        Debug.Log("로딩 종료");
        loadUI_AD.FadeOut();
        yield return new WaitForSecondsRealtime(0.5f);
    }

    private void LoadAsync_BT()
    {
        StartCoroutine(LoadingRoutine_BT());
    }
    private void LoadAsync_AD()
    {
        StartCoroutine(LoadingRoutine_AD());
    }

    IEnumerator LoadingRoutine_BT()
    {
        progress = 0.5f;
        SceneRecreated();
        yield return new WaitForSecondsRealtime(2.5f);
        GameManager.UI.ShowWindowUI<SelectBoxUI>("UI/SelectBoxUI");
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("준비완료_BT");
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(0.5f);
    }

    IEnumerator LoadingRoutine_AD()
    {
        progress = 0.5f;
        SceneRecreated();
        yield return new WaitForSecondsRealtime(2.5f);
        progress = 0.8f;
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("준비완료_AD");
        progress = 1.0f;
        yield return new WaitForSecondsRealtime(0.5f);
    }
    public void SceneRecreated()
    {
        GameManager.Pool.Recreated();
        GameManager.UI.Recreated();
    }

    public void SceneClear()
    {
        GameManager.UI.Clear();
        GameManager.Pool.Clear();
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if(eventType == EventType.BTin)
        {
            GameManager.Event.RemoveEvent(EventType.BTin);
            BTLoadScene("BattleScene");
        }
        if(eventType == EventType.ADin)
        {
            GameManager.Event.RemoveEvent(EventType.ADin);
            ADLoadScene("AdventureScene");
        }
    }
}
