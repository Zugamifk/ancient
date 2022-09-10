using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.Data
{
    public class PortalDefenseStructurePrefabs : ScriptableObject, IPrefabLookup
    {
        [SerializeField]
        GameObject[] _prefabs;

        Dictionary<string, GameObject> _prefabNametoPrefab = new();

        public GameObject GetPrefab(string key) => _prefabNametoPrefab[key];

        void OnEnable()
        {
            foreach(var go in _prefabs)
            {
                _prefabNametoPrefab.Add(go.name, go);
            }
            Prefabs.Register<ITileStructure>(this);
        }
    }
}
