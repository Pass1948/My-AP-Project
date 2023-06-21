using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonActUI : PopUpUI, IEventListener
{
    protected override void Awake()
    {
        base.Awake();
        buttons["TimingButton"].onClick.AddListener(() => { PressButton(); });
    }

    private void Start()
    {
        GameManager.Event.PostNotification(EventType.SelectTarget, this);
        StartCoroutine(CountDownRoutine());
    }

    private void PressButton()
    {
        Debug.Log("�� ��ư�� ������");
        GameManager.Event.PostNotification(EventType.PressButton, this);
        StopCoroutine(CountDownRoutine());
        this.gameObject.SetActive(false);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {}

    IEnumerator CountDownRoutine()
    {
        Debug.Log("��ư�׼� ����");
        yield return new WaitForSecondsRealtime(2.5f);
        GameManager.Event.PostNotification(EventType.PressFail, this);
        this.gameObject.SetActive(false);
    }
}
