using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private PlayerController player;
    public int hp = 5;
    public int damage = 2;
    public bool dead =false;

    protected virtual void Awake()
    {
        player = GameManager.Resource.Instantiate<PlayerController>("Player/Player");
    }
}
