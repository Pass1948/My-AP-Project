using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSaveData : MonoBehaviour
{
    private int hp;
    private float[] position;
    private Player player_AD;
    private Player player_BT;


    private void Awake()
    {
        player_AD = GameManager.Resource.Load<Player>("Player/Adventure/AdventurePlayer");
        player_BT = GameManager.Resource.Load<Player>("Player/Battle/BattlePlayer");
    }

    public void CurHP(DataBase player)
    {
        hp = player.Player[1].curHP;
        player_AD.curHP = hp;
    }

    private void CurPosition()
    {
        position = new float[3];
        position[0] = player_AD.transform.position.x;
        position[1] = player_AD.transform.position.y;
        position[2] = player_AD.transform.position.z;
    }
}
