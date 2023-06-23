using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    GameObject player;
    GameObject spawnPoint;

    private void Awake()
    {
        spawnPoint = GameManager.Resource.Load<GameObject>("Player/Battle/PlayerSpawn");
        player = GameManager.Resource.Load<GameObject>("Player/Battle/BattlePlayer");
    }

    private void Start()
    {
        GameManager.Resource.Instantiate(player, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
