using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModel;

namespace TowerDefense.Models
{
    public class TowerDefenseGameModel : ITowerDefense
    {
        public Vector2Int EndPoint;
        public int Lives;
        public int MaxLives;
        public TimeSpan StartTime;
        public TimeSpan CurrentTime;
        public int SpawnedCount { get; set; }
        public int CurrentWave = -1;
        public List<Guid> EnemyIds = new List<Guid>();
        public string BuildingBeingPlaced;
        public IdentifiableCollection<Tower> Towers = new IdentifiableCollection<Tower>();
        public IdentifiableCollection<Projectile> Projectiles = new IdentifiableCollection<Projectile>();

        public MapModel MapModel { get; } = new("TowerDefense");

        public int Coins { get; set; }
        #region ITurretDefenseViewModel
        int ITowerDefense.Lives => Lives;

        int ITowerDefense.MaxLives => MaxLives;

        int ITowerDefense.CurrentWave => CurrentWave;

        int ITowerDefense.TotalWaves => 0;

        TimeSpan ITowerDefense.CurrentTime => CurrentTime;

        string ITowerDefense.BuildingBeingPlaced => BuildingBeingPlaced;

        IIdentifiableLookup<ITower> ITowerDefense.Towers => Towers;

        IIdentifiableLookup<IProjectile> ITowerDefense.Projectiles => Projectiles;

        IEnumerable<Guid> ITowerDefense.EnemyIds => EnemyIds;

        IMapModel ITowerDefense.Map => MapModel;
        #endregion
    }
}