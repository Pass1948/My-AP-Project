using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI_BTEnd : BaseScene, IEventListener
{
    private Animator anim;

    private void Awake()
    {
        GameManager.Event.AddListener(EventType.Result, this);
        anim = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        anim.SetBool("Active", true);
    }

    public void FadeOut()
    {
        anim.SetBool("Active", false);
    }

    protected override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.Result)
        {
            GameManager.Scene.ADLoadScene("AdventureScene");
            GameManager.Event.RemoveEvent(EventType.Result);
        }
    }
}
