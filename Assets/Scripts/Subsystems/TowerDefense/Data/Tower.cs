using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Data
{
    public class Tower : ScriptableObject
    {
        public string Name;
        public float Radius;
        public float ShotsPerSecond;
        public float Damage;
        public GameObject Prefab;
    }
}