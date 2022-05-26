using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;

namespace TowerDefense.Models
{
    public class Tower : ITower
    {
        public string Key { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Vector2Int Position { get; set; }
        public float AttackRadius { get; set; }
        public HashSet<Guid> EnemiesInRange = new HashSet<Guid>();
        public float ShotsPerSecond { get; set; }
        public float ShotCooldown { get; set; }
        IEnumerable<Guid> ITower.EnemiesInRange => EnemiesInRange;
    }
}