using System.Collections;
using System.Collections.Generic;
using TowerDefense.ViewModels;
using UnityEngine;

namespace TowerDefense.Data
{
    public class TowerDefenseData : ScriptableObject, IPrefabLookup
    {
        public int StartingLives;
        public TurretDefenseWaveData[] Waves;
        public Tower[] Turrets;

        Dictionary<string, Tower> _turretNameToData = new Dictionary<string, Tower>();
        private void OnEnable()
        {
            foreach (var t in Turrets)
            {
                _turretNameToData.Add(t.name, t);
            }
            Prefabs.Register<ITower>(this);
        }

        public Tower GetTurret(string name) => _turretNameToData[name];

        public GameObject GetPrefab(string key) => GetTurret(key).Prefab;
    }
}