using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Data
{
    public class TowerDefenseWaveData : ScriptableObject
    {
        public CharacterData Enemy;
        public int Count;
        public float SpawnTime;
    }
}