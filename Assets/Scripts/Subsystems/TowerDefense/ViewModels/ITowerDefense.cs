using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.ViewModels
{
    public interface ITowerDefense
    {
        int Lives { get; }
        int MaxLives { get; }
        int CurrentWave { get; }
        int SpawnedCount { get; }
        int TotalWaves { get; }
        TimeSpan CurrentTime { get; }
        IIdentifiableLookup<ITower> Turrets { get; }
        string BuildingBeingPlaced { get; }
        IIdentifiableLookup<IProjectile> Projectiles { get; }
        IEnumerable<Guid> EnemyIds { get; }
    }
}