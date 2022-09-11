using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.Data
{
    public class PortalDefenseEnemyPrefabs : ScriptableObject, IPrefabLookup, IRegisteredData
    {
        [SerializeField]
        GameObject[] _prefabs;
        [SerializeField]
        PortalDefenseEnemyData[] _enemyData;
        
        Dictionary<string, GameObject> _keyToPrefab = new();
        Dictionary<string, PortalDefenseEnemyData> _keyToData = new();

        private void OnEnable()
        {
            foreach(var p in _prefabs)
            {
                _keyToPrefab.Add(p.name, p);
            }

            foreach(var d in _enemyData)
            {
                _keyToData.Add(d.Key, d);
            }
            Prefabs.Register<IEnemyModel>(this);
        }

        public GameObject GetPrefab(string key) => _keyToPrefab[key];
        public PortalDefenseEnemyData GetData(string key) => _keyToData[key];
    }
}
