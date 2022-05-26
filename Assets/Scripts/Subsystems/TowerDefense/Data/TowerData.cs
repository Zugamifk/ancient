using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Data
{
    public class TowerData : ScriptableObject, IPrefabReference
    {
        public string Name;
        public float Radius;
        public float ShotsPerSecond;
        public float Damage;
        public GameObject Prefab;

        string IPrefabReference.Name => Name;
        GameObject IPrefabReference.Prefab => Prefab;
    }
}