using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private string playerName;

    public string PlayerName { get { return playerName; } set { playerName = value; } }

    private void Awake()
    {
        playerName = gameObject.name;
    }
}
