using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Data
{
    public class EnemyDataCollection : ScriptableObject
    {
        public EnemyData[] Enemies;
        Dictionary<string, EnemyData> _enemyKeyToData = new();

        private void OnEnable()
        {
            foreach(var e in Enemies)
            {
                _enemyKeyToData[e.Name] = e;
            }
        }

        public EnemyData GetEnemy(string key) => _enemyKeyToData[key];
    }
}
