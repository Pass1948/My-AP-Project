using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalSpawner : MonoBehaviour, IEventListener
{
    GameObject enemy;
    GameObject spawnPoint;
    private void Awake()
    {
        GameManager.Event.AddListener(EventType.Nomal, this);
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/EnemySpawn");
        enemy = GameManager.Resource.Load<GameObject>("Enemy/Enemy");
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if (eventType == EventType.Nomal)
        {
            Spawn();
            GameManager.Event.RemoveEvent(EventType.Nomal);
        }

    }

    private void Spawn()
    {
        GameManager.Resource.Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    
}
