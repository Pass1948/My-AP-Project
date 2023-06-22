using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDate", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField] PlayerInfo[] player;

    public PlayerInfo[] Player { get { return player; } }

    [Serializable]
    public class PlayerInfo
    {
        public int hp;
        public int damage;
    }
}
