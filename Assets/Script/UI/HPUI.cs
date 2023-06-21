using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : InGameUI, IEventListener
{
    [SerializeField] Player player;
    private Slider slider;
    protected override void Awake()
    {
        base.Awake();
        GameManager.Event.AddListener(EventType.ChangedPlayerHP, this);
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        slider.maxValue = player.hp;
    }
    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.ChangedPlayerHP)
        {
            slider.value = player.hp;
        }
    }
}
