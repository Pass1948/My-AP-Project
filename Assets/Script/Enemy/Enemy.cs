using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damage;

    public int maxHP;
    private int curHP;
    public int CurHP { get { return curHP; } set {  curHP = value; } }

    private void Awake()
    {
        curHP = 0;
        curHP = maxHP;
    }

    public bool TakeDamage(int dmg)
    {
        curHP -= dmg;
        Debug.Log("����");
        if (curHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
