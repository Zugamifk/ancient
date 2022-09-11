using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.Model
{
    public class PortalDefenseModel : IPortalDefenseModel
    {
        public MapModel Map { get; set; } = new();
        public IdentifiableCollection<EnemyModel> SpawnedEnemies = new();
        public IdentifiableCollection<EnemySpawnModel> Spawns = new();
        public WaveModel CurrentWave { get; set; }
        IMapModel IPortalDefenseModel.Map => Map;

        IWaveModel IPortalDefenseModel.CurrentWave => CurrentWave;

        IIdentifiableLookup<IEnemySpawnModel> IPortalDefenseModel.Spawns => Spawns;

        IIdentifiableLookup<IEnemyModel> IPortalDefenseModel.SpawnedEnemies => SpawnedEnemies;
    }
}
