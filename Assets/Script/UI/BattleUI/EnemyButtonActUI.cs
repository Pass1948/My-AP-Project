using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EnemyButtonActUI : PopUpUI, IEventListener
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

    private void PressButton()
    {
        Debug.Log("�� ��ư�� ������");
        GameManager.Event.PostNotification(EventType.PressButton_ET, this);
        StopCoroutine(CountDownRoutine());
        GameManager.UI.ClosePopUpUI();
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    { }

    IEnumerator CountDownRoutine()
    {
        Debug.Log("��ư�׼� ����");
        yield return new WaitForSecondsRealtime(2.5f);
        GameManager.Event.PostNotification(EventType.PressFail_ET, this);
        GameManager.UI.ClosePopUpUI();
        yield break;
    }
}
