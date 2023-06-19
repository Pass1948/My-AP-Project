using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemData;

[CreateAssetMenu(fileName = "PlayerDate", menuName = "Data/Player")]
public class PlayerDate : ScriptableObject
{
    [SerializeField] PlayerInfo[] player;

    public PlayerInfo[] Player { get { return player; } }

    [Serializable]
    public class PlayerInfo
    {

        public PlayerController player;

        public int hp;
        public int damage;
    }
}
