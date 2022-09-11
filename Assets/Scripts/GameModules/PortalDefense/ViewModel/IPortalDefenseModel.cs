using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.ViewModel
{
    public interface IPortalDefenseModel : IRegisteredModel
    {
        IMapModel Map { get; }
        IWaveModel CurrentWave { get; }
        IIdentifiableLookup<IEnemyModel> SpawnedEnemies { get; }
        IIdentifiableLookup<IEnemySpawnModel> Spawns { get; }
    }
}
