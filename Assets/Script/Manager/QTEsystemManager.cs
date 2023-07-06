using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEsystemManager : MonoBehaviour, IEventListener
{
    private int correctKey;          // 키입력 성공/실패 여부

    public void Start()
    {
        GameManager.Event.AddListener(EventType.PressButton_PT, this);
        GameManager.Event.AddListener(EventType.PressFail_PT, this);
        GameManager.Event.AddListener(EventType.PressButton_ET, this);
        GameManager.Event.AddListener(EventType.PressFail_ET, this);
    }
    public void Success()
    {
        correctKey = 1;
        GameManager.Event.RemoveEvent(EventType.PressButton_PT);
        StartCoroutine(KeyPressingRoutine());
    }

    public void fail()
    {
        correctKey = 2;
        GameManager.Event.RemoveEvent(EventType.PressFail_PT);
        StartCoroutine(KeyPressingRoutine());
    }

    public void Success_Enemy() 
    {
        correctKey = 1;
        GameManager.Event.RemoveEvent(EventType.PressButton_ET);
        StartCoroutine(KeyPressingRoutine_ET());
    }

    public void fail_Enemy()
    {
        correctKey = 2;
        GameManager.Event.RemoveEvent(EventType.PressFail_ET);
        StartCoroutine(KeyPressingRoutine_ET());
    }

    IEnumerator KeyPressingRoutine()
    {
        if (correctKey == 1)    //  성공했을경우
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("버튼성공");
            GameManager.Event.PostNotification(EventType.Sucess, this);
            GameManager.Event.PostNotification(EventType.Sucess_Ani, this);
            yield return new WaitForSeconds(0.5f);
            correctKey = 0;
            yield break;
        }
        if (correctKey == 2)  //실패했을경우
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("버튼실패");
            GameManager.Event.PostNotification(EventType.Fail, this);
            GameManager.Event.PostNotification(EventType.Fail_Ani, this);
            yield return new WaitForSeconds(0.5f);
            correctKey = 0;
            yield break;
        }
    }

    IEnumerator KeyPressingRoutine_ET()
    {
        if (correctKey == 1)    //  성공했을경우
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("버튼성공");
            GameManager.Event.PostNotification(EventType.Sucess_ET, this);
            GameManager.Event.PostNotification(EventType.Sucess_ET_Ani, this);
            yield return new WaitForSeconds(0.5f);
            correctKey = 0;
            yield break;
        }
        if (correctKey == 2)  //실패했을경우
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("버튼실패");
            GameManager.Event.PostNotification(EventType.Fail_ET, this);
            GameManager.Event.PostNotification(EventType.Fail_ET_Ani, this);
            yield return new WaitForSeconds(0.5f);
            correctKey = 0;
            yield break;
        }
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case EventType.PressButton_PT:
                Success();
                break;
            case EventType.PressFail_PT:
                fail();
                break;
            case EventType.PressButton_ET:
                Success_Enemy();
                break;
            case EventType.PressFail_ET:
                fail_Enemy();
                break;
        }
    }
}
