using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    GameObject player;
    GameObject spawnPoint;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        spawnPoint = GameManager.Resource.Load<GameObject>("Player/PlayerSpawn");
        player = GameManager.Resource.Load<GameObject>("Player/Player");
        GameManager.Resource.Instantiate(player, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
