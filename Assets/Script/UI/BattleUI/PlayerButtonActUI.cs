using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerButtonActUI : PopUpUI, IEventListener
{
    protected override void Awake()
    {
        base.Awake();
        buttons["TimingButton"].Select();
        buttons["TimingButton"].onClick.AddListener(() => { PressButton(); });
    }

    private void Start()
    {
        StartCoroutine(CountDownRoutine());
    }
    private void LateUpdate()
    {
        buttons["TimingButton"].Select();
    }

    private void PressButton()
    {
        Debug.Log("넌 버튼을 눌렀지");
        GameManager.Event.PostNotification(EventType.PressButton_PT, this);
        StopCoroutine(CountDownRoutine());
        GameManager.UI.ClosePopUpUI();
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {}

    IEnumerator CountDownRoutine()
    {
        Debug.Log("버튼액션 시작");
        yield return new WaitForSeconds(1.5f);
        GameManager.Event.PostNotification(EventType.PressFail_PT, this);
        GameManager.UI.ClosePopUpUI();
        yield return new WaitForSeconds(0.5f);
    }
}
