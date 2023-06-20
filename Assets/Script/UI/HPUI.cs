using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour, IEventListener
{
    [SerializeField] Player player;

    private Slider slider;

   

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = player.hp;
        slider.value = player.hp;
    }
    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        
        if (eventType != EventType.ChangedPlayerHP)
        {
            return;
        }
        if (eventType == EventType.ChangedPlayerHP)
        {
            GameManager.Event.AddListener(EventType.ChangedPlayerHP, this);
        }
    }
}
