using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour, IEventListener
{
    GameObject boss;
    GameObject spawnPoint;

    private void Awake()
    {
        GameManager.Event.AddListener(EventType.BossMeet, this);
    }
    private void Start()
    {
    }
    private void Spawn()
    {
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/Boss/BossSpawn");
        boss = GameManager.Resource.Load<GameObject>("Enemy/Boss/Boss_BT");
        GameManager.Resource.Instantiate(boss, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if(eventType == EventType.BossMeet)
        Spawn();
    }
}
