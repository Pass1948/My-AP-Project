using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : InGameUI, IEventListener
{
    //private PlayerController player;
    private Slider slider;
    protected override void Awake()
    {
        base.Awake();
        //player = GameManager.Resource.Load<PlayerController>("Player/Player");
        GameManager.Event.AddListener(EventType.ChangedPlayerHP, this);
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        //slider.maxValue = player.hp;
        //slider.value = player.hp;
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {}
}
