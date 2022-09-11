using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.Data
{
    public class PortalDefenseEnemyPrefabs : ScriptableObject, IPrefabLookup
    {
        public GameObject[] _prefabs;

        Dictionary<string, GameObject> _keyToPrefab = new();

        private void OnEnable()
        {
            foreach(var p in _prefabs)
            {
                _keyToPrefab.Add(p.name, p);
            }
            Prefabs.Register<IEnemyModel>(this);
        }

        public GameObject GetPrefab(string key) => _keyToPrefab[key];
    }
}
