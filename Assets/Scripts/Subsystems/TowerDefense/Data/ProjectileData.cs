using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Data
{
    public class ProjectileData : ScriptableObject, IPrefabReference
    {
        [SerializeField]
        GameObject _prefab;

        public string Name => name;

        public GameObject Prefab => _prefab;
    }
}
