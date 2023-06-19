using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] DamageItemInfo[] damageItem;
    public DamageItemInfo[] DamageItem { get { return damageItem; } }


    [Serializable]
    public class DamageItemInfo
    {

        public Item item;

        public int damage;
        public float useDellay;

        public int buildCost;
        public int sellCost;
    }

    [SerializeField] RecovaryItemInfo[] recovaryItem;
    public RecovaryItemInfo[] RecovaryItem { get { return recovaryItem; } }


    [Serializable]
    public class RecovaryItemInfo
    {

        public Item item;

        public int damage;
        public float useDellay;

        public int buildCost;
        public int sellCost;
    }

    // 함수 호출가능
}
