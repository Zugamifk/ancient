using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModel;

namespace TowerDefense.Models
{
    public class Projectile : IProjectile, IIdentifiable, IKeyHolder
    {
        public string Key { get; set; }
        public Guid MapId { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        public float FlightProgress { get; set; }
        public Vector2 Position => Trajectory.Position;
        public PathFollower Trajectory { get; set; }
        public float MoveSpeed { get; set; }
    }
}