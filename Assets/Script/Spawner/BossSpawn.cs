using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour, IEventListener
{
    GameObject boss;
    GameObject spawnPoint;

    private void Awake()
    {
        GameManager.Event.AddListener(EventType.Boss, this);
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/Boss/BossSpawn");
        boss = GameManager.Resource.Load<GameObject>("Enemy/Boss/Boss_BT");
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.Boss)
        {
            Spawn();
            GameManager.Event.RemoveEvent(EventType.Boss);
        }
            
    }

    private void Spawn()
    {
        GameManager.Resource.Instantiate(boss, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    
}
