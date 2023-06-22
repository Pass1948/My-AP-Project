using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEsystemManager : MonoBehaviour, IEventListener
{
    private PlayerController player;
    private EnemyController enemy;
    private int correctKey;          // 키입력 성공/실패 여부
    private bool isKeyDown = false;

    private void Awake()
    {
        player = new PlayerController();
        enemy = new EnemyController();  

        GameManager.Event.RemoveEvent(EventType.SelectAttack);
        GameManager.Event.RemoveEvent(EventType.EnemyTurnEnd);

        GameManager.Event.AddListener(EventType.PressButton, this);
        GameManager.Event.AddListener(EventType.PressFail, this);
    }
    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.PressButton)
        {
            Debug.Log("크리티컬");
            correctKey = 1;
            player.Attack();
            StartCoroutine(KeyPressingRoutine());
        }
        if (eventType == EventType.PressFail)
        {
            Debug.Log("일반공격");
            correctKey = 2;
            player.Attack();
            StartCoroutine(KeyPressingRoutine());
        }

    }
    public void EnemyTurnAction()
    {
        /// 나중에 passd button ui 나오는 애니메이션 적용
        if (!isKeyDown)
        {
            Debug.Log("피해받음");
            correctKey = 2;
            enemy.Attack();
            StartCoroutine(KeyPressingRoutine());
        }
        else
        {
            Debug.Log("반격");
            correctKey = 1;
            player.Attack();
            StartCoroutine(KeyPressingRoutine());
        }
    }

    IEnumerator KeyPressingRoutine()
    {
        if (correctKey == 1)    //  성공했을경우
        {
            Debug.Log("버튼성공");
            correctKey = 0;
            GameManager.Event.PostNotification(EventType.ButtonActResult, this);
            yield return new WaitForSecondsRealtime(1f);

            GameManager.Event.RemoveEvent(EventType.PressButton);
            GameManager.Event.RemoveEvent(EventType.PressFail);
            yield return new WaitForSecondsRealtime(0.5f);
        }
        if (correctKey == 2)  //실패했을경우
        {
            Debug.Log("버튼실패");
            correctKey = 0;
            GameManager.Event.PostNotification(EventType.ButtonActResult, this);
            yield return new WaitForSecondsRealtime(1f);

            GameManager.Event.RemoveEvent(EventType.PressButton);
            GameManager.Event.RemoveEvent(EventType.PressFail);
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
