using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject enemy;
    GameObject spawnPoint;

    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        spawnPoint = GameManager.Resource.Load<GameObject>("Enemy/EnemySpawn");
        enemy = GameManager.Resource.Load<GameObject>("Enemy/Enemy");
        GameManager.Resource.Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
