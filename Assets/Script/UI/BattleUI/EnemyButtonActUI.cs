using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class EnemyButtonActUI : WindowUI, IEventListener
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
        Debug.Log("�� ��ư�� ������");
        GameManager.Event.PostNotification(EventType.PressButton_ET, this);
        StopCoroutine(CountDownRoutine());
        GameManager.UI.CloseWindowUI(this);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    { }

    IEnumerator CountDownRoutine()
    {
        Debug.Log("��ư�׼� ����");
        yield return new WaitForSecondsRealtime(2.5f);
        GameManager.Event.PostNotification(EventType.PressFail_ET, this);
        GameManager.UI.CloseWindowUI(this);
        yield break;
    }
}
