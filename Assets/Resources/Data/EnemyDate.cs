using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[CreateAssetMenu(fileName = "EnemyDate", menuName = "Data/Enemy")]
public class EnemyDate : ScriptableObject
{
        [SerializeField] EnmeyInfo[] enemy;

        public EnmeyInfo[] Enemy { get { return enemy; } }

        [Serializable]
        public class EnmeyInfo
    {

            public Enemy enemy;

            public int hp;
            public int damage;
        }
}
