using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Data
{
    public class EnemyData : ScriptableObject
    {
        [field:SerializeField]
        public string Name { get; set; }
        public int CoidReward;
    }
}
