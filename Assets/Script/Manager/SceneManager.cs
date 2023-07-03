using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    private LoadingUI_BTStart loadUI_BT;
    private LoadingUI_BTEnd loadUI_AD;
    private BaseScene curScene;

    public BaseScene CurScene
    {
        get
        {
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();

            return curScene;
        }
    }

    private void Awake()
    {
        LoadingUI_BTStart uiStart = Resources.Load<LoadingUI_BTStart>("UI/LoadingUI/LoadingUI_BTStart");
        loadUI_BT = Instantiate(uiStart);
        loadUI_BT.transform.SetParent(transform);

        LoadingUI_BTEnd uiEnd = Resources.Load<LoadingUI_BTEnd>("UI/LoadingUI/LoadingUI_BTEnd");
        loadUI_AD = Instantiate(uiEnd);
        loadUI_AD.transform.SetParent(transform);
    }

    public void BTLoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine_BD(sceneName));
    }

    public void ADLoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine_AD(sceneName));
    }

    IEnumerator LoadingRoutine_BD(string sceneName)
    {
        Time.timeScale = 0f;
        loadUI_BT.BattleActive();
        yield return new WaitForSecondsRealtime(4.5f);

        yield return new WaitForSecondsRealtime(0.5f);
        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);

        while (!oper.isDone)
        {
            yield return null;
        }
        CurScene.LoadAsync();
        while (CurScene.progress < 1f)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        loadUI_BT.BattleActiveEnd();
        yield return new WaitForSecondsRealtime(1f);
    }

    IEnumerator LoadingRoutine_AD(string sceneName)
    {
        Time.timeScale = 0f;
        loadUI_AD.FadeIn();
        yield return new WaitForSecondsRealtime(0.5f);

        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForSecondsRealtime(0.5f);

        while (!oper.isDone)
        {
            yield return null;
        }
        CurScene.LoadAsync();
        while (CurScene.progress < 1f)
        {
            yield return null;
        }

        Time.timeScale = 1f;
        loadUI_AD.FadeOut();
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
