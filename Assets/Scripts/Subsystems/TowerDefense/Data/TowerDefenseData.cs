using System.Collections;
using System.Collections.Generic;
using TowerDefense.ViewModels;
using UnityEngine;

namespace TowerDefense.Data
{
    public class TowerDefenseData : SimplePrefabLookup<ITower, TowerData>
    {
        public TowerData[] Towers;
        public int StartingLives;
        public TowerDefenseWaveData[] Waves;

        protected override IEnumerable<TowerData> PrefabReferences => Towers;

        public TowerData GetTower(string key) => this[key];
    }
}