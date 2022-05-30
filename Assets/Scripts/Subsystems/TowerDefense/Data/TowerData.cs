using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Data
{
    public class TowerData : ScriptableObject, IPrefabReference
    {
        public string Name;
        public Sprite Sprite;

        public float Radius;
        public float ShotsPerSecond;
        public float Damage;

        public int BuildCost;
        
        public GameObject Prefab;

        string IPrefabReference.Name => Name;
        GameObject IPrefabReference.Prefab => Prefab;
    }
}