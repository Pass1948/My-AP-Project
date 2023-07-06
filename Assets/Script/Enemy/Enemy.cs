using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;

    public int maxHP;
    public int curHP;

    public bool TakeDamage(int dmg)
    {
        curHP -= dmg;
        Debug.Log("¾ÆÆÄ");
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
