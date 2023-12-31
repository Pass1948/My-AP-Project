using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum EventType
{
    // 1. FSM
    //  a.플레이어턴
    PlayerTurn,
    PlayerTurnEnd,

    // b. PlayerState
    Attack,
    PlayerAttack,
    PlayerActionEnd,
    Run,

    // d. Enemyturn
    EnemyTurn,

    // c. EnemyState
    EnemyAttack,
    EnemyTurnEnd,

    //========버튼액션========
    AttackMiss,
    Sucess,
    Fail,
    Sucess_ET,
    Fail_ET,

    // 버튼 액션 전용
    Result,
    PressFail_PT,
    PressFail_ET,

    // 버튼누름(PlayerButtonActUI)
    PressButton_PT,
    PressButton_ET,

    //=======================

    // SelectBoxUI
    SelectAttack,
    SelectRun,
    SelectTarget,

    // 플레이어 생존
    PlayerisLive,
    PlayerDied,

    // 적 생존
    EnemyisLive,
    EnemyDied,
    EnemyRun,

    //승패
    Win,
    Loss,
    Draw,

    //ui
    Close,

    //몬스터 구별
    BossMeet,
    NomalMeet,
    Boss,
    Nomal,

    // Boss
    BossTurn,
    BossActack,
    BossisLive,
    BossDied,
    BossClose,

    // 애니메이션 전용
    // 1.플레이어 전용
    NomalAttack_Ani,
    Sucess_Ani,
    Fail_Ani,
    Dead_P,

    // 2. 몬스터
    Moving_E_Ani,
    Dead_E_Ani,
    Sucess_ET_Ani,
    Fail_ET_Ani,

    // Scene전환
    BTin,
    ADin,

};

public class EventManager : MonoBehaviour
{
    // 이벤트 리스너 리스트를 Dictionary를 통해 관리 EventType은 IN과 OUT으로 두가지 분류의 리스트로 관리
    private Dictionary<EventType, List<IEventListener>> Listeners = new Dictionary<EventType, List<IEventListener>>();

    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManagerSceneLoaded;
    }
    private void OnDisable() 
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= SceneManagerSceneLoaded;
    }
    private void SceneManagerSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //씬이 바뀜에 따라 이벤트 의존성을 제거해준다.
        RefreshListeners();
    }

    public void AddListener(EventType eventType, IEventListener Listener)       // 이벤트 받는 역할
    {
        List<IEventListener> ListenList = null;

        if (Listeners.TryGetValue(eventType, out ListenList))
        {
            //해당 이벤트 키값이 존재한다면, 이벤트를 추가해준다.
            ListenList.Add(Listener);
            return;
        }
            ListenList = new List<IEventListener>();
            ListenList.Add(Listener);
            Listeners.Add(eventType, ListenList);
    }

    public void PostNotification(EventType eventType, Component Sender, object Param = null) // 이벤트 발생역할
    {
        List<IEventListener> ListenList = null;

        //이벤트 리스너(대기자)가 없으면 그냥 리턴.

        if (!Listeners.TryGetValue(eventType, out ListenList))
            return;


        //모든 이벤트 리스너(대기자)에게 이벤트 전송.
        for (int i = 0; i < ListenList.Count; i++)
        {
            if (!ListenList[i].Equals(null)) //If object is not null, then send message via interfaces
                ListenList[i].OnEvent(eventType, Sender, Param);
        }
    }


    public void RemoveEvent(EventType eventType)        // 이벤트 삭제
    {
        Listeners.Remove(eventType);
    }

    private void RefreshListeners()     // Scene전환시 모든 이벤트 초기화
    {
        //임시 Dictionary 생성
        Dictionary<EventType, List<IEventListener>> TmpListeners = new Dictionary<EventType, List<IEventListener>>();

        //씬이 바뀜에 따라 리스너가 Null이 된 부분을 삭제해준다. 
        foreach (KeyValuePair<EventType, List<IEventListener>> Item in Listeners)
        {
            for (int i = Item.Value.Count - 1; i >= 0; i--)
            {
                if (Item.Value[i].Equals(null))
                    Item.Value.RemoveAt(i);
            }

            if (Item.Value.Count > 0)
                TmpListeners.Add(Item.Key, Item.Value);
        }
        //살아있는 리스너는 다시 넣어준다.
        Listeners = TmpListeners;
    }


}


