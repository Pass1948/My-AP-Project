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
    // �÷��̾���
    PlayerTurn,
    PlayerTurnEnd,

    //�÷��̾� ���ø�ħ
    PlayerActionEnd,

    //====�÷��̾� ��ư�׼�====
    // �÷��̾� ����
    Attack,
    AttackSuccess,
    AttackMiss,

    // �÷��̾� ȸ��(�����ϰ��)
    AvoidanceSuccess,
    AvoidanceMiss,
    //=======================

    // �÷��̾� ����
    Run,

    // �÷��̾� ����
    ChangedPlayerHP,
    PlayerDied,

    // ����
    EnemyTurn,
    EnemyTurnEnd,

    //�� �ൿ��ħ
    EnemyActionEnd,

    // �� ����
    EnemyAttack,
    EnemyAttackEnd,

    // �� ����
    EnemyRun,

    // �� ����
    ChangedEnemyHP,
    EnemyDied,

    // ����
    Win,
    Loss,
};

public class EventManager : MonoBehaviour
{
    // �̺�Ʈ ������ ����Ʈ�� Dictionary�� ���� ���� EventType�� IN�� OUT���� �ΰ��� �з��� ����Ʈ�� ����
    private Dictionary<EventType, List<IEventListener>> Listeners = new Dictionary<EventType, List<IEventListener>>();

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManagerSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManagerSceneLoaded;
    }
    private void SceneManagerSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //���� �ٲ� ���� �̺�Ʈ �������� �������ش�.
        RefreshListeners();
    }

    public void PostNotification(EventType eventType, Component Sender, object Param = null) // �̺�Ʈ �߻�����
    {
        List<IEventListener> ListenList = null;

        //�̺�Ʈ ������(�����)�� ������ �׳� ����.
        if (!Listeners.TryGetValue(eventType, out ListenList))
            return;

        //��� �̺�Ʈ ������(�����)���� �̺�Ʈ ����.
        for (int i = 0; i < ListenList.Count; i++)
        {
            Debug.Log("�̺�Ʈ �߻�");
            if (!ListenList[i].Equals(null)) //If object is not null, then send message via interfaces
                ListenList[i].OnEvent(eventType, Sender, Param);
        }
    }
    public void AddListener(EventType eventType, IEventListener Listener)       // �̺�Ʈ �޴� ����
    {
        List<IEventListener> ListenList = null;

        if (Listeners.TryGetValue(eventType, out ListenList))
        {
            //�ش� �̺�Ʈ Ű���� �����Ѵٸ�, �̺�Ʈ�� �߰����ش�.
            ListenList.Add(Listener);
            return;
        }

        ListenList = new List<IEventListener>();
        ListenList.Add(Listener);
        Listeners.Add(eventType, ListenList);
    }
    public void RemoveEvent(EventType eventType)        // �̺�Ʈ ����
    {
        Listeners.Remove(eventType);
    }

    private void RefreshListeners()     // Scene��ȯ�� ��� �̺�Ʈ �ʱ�ȭ
    {
        //�ӽ� Dictionary ����
        Dictionary<EventType, List<IEventListener>> TmpListeners = new Dictionary<EventType, List<IEventListener>>();

        //���� �ٲ� ���� �����ʰ� Null�� �� �κ��� �������ش�. 
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
        //����ִ� �����ʴ� �ٽ� �־��ش�.
        Listeners = TmpListeners;
    }

}


