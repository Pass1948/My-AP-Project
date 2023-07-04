using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class DataBase : ScriptableObject
{

    [SerializeField] PlayerInfo[] player;
    public PlayerInfo[] Player { get { return player; } }


    [Serializable]
    public class PlayerInfo
    {
        public Player player;
        public Transform transform;
        public int damage;
        public int maxHP;
        public int curHP;
    }
}

    
