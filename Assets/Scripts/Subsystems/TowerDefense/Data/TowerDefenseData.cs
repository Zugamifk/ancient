using System.Collections;
using System.Collections.Generic;
using TowerDefense.ViewModel;
using UnityEngine;

namespace TowerDefense.Data
{
    public class TowerDefenseData : SimplePrefabLookup<ITower, TowerData>
    {
        public TowerData[] Towers;
        public int StartingLives;
        public TowerDefenseWaveData[] Waves;
        public int StartingCoins;

        protected override IEnumerable<TowerData> PrefabReferences => Towers;

        public TowerData GetTower(string key) => this[key];
    }
}