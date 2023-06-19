using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[CreateAssetMenu(fileName = "EnemyDate", menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
        [SerializeField] EnmeyInfo[] enemy;

        public EnmeyInfo[] Enemy { get { return enemy; } }

        [Serializable]
        public class EnmeyInfo
    {

            public EnemyController enemy;

            public int hp;
            public int damage;
        }
}
