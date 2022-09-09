using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.ViewModel;
using UnityEngine;
using ViewModel;

namespace TowerDefense.ViewModel
{
    public interface ITowerDefense : IRegisteredModel
    {
        int Lives { get; }
        int MaxLives { get; }
        int CurrentWave { get; }
        int SpawnedCount { get; }
        int TotalWaves { get; }
        TimeSpan CurrentTime { get; }
        IIdentifiableLookup<ITower> Towers { get; }
        string BuildingBeingPlaced { get; }
        IIdentifiableLookup<IProjectile> Projectiles { get; }
        IEnumerable<Guid> EnemyIds { get; }
        int Coins { get; }
        IMapModel Map { get; }
    }
}