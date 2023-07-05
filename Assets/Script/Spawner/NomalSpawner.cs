using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalSpawner : MonoBehaviour, IEventListener
{
    GameObject enemy;
    GameObject spawnPoint;
    private void Awake()
    {
        GameManager.Event.AddListener(EventType.NomalMeet, this);
    }

    private void Start()
    {
        
    }
    private void Spawn()
    {
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/EnemySpawn");
        enemy = GameManager.Resource.Load<GameObject>("Enemy/Enemy");
        GameManager.Resource.Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void OnEvent(EventType eventType, Component Sender, object Param = null)
    {
        if(eventType == EventType.NomalMeet)
        Spawn();
    }
}
