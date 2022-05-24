using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;

namespace TowerDefense.Views
{
    public class TowerPrefabLookup : IPrefabLookup
    {
        Dictionary<string, GameObject> _lookup;
        public TowerPrefabLookup(TowerDefenseData data)
        {
            _lookup = new();
            foreach (var d in data.Towers)
            {
                _lookup[d.Name] = d.Prefab;
            }
        }

        public GameObject GetPrefab(string key) => _lookup[key];

    }
}